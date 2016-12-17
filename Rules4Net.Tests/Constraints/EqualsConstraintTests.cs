﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rules4Net.Data;
using Rules4Net.Data.Constraints;
using Rules4Net.Engine;
using Rules4Net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules4Net.Tests.Constraints
{
    [TestClass]
    public class EqualsConstraintTests
    {
        [TestMethod]
        public void ShouldBePossibleEvaluateRuleWithEqualsConstraint()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "John Doe";

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(1, rules.Count());

            pool.Clear();
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNotEqualValue()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = "Fake User";

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(0, rules.Count());

            pool.Clear();
        }

        [TestMethod]
        public void ShouldNotBePossibleEvaluateRuleWithEqualsConstraintAndNullValue()
        {
            var pool = MemoryPool.Default;

            var rule = new Rule();
            var filter = rule.AddAndFilter();
            filter.Add(new EqualsConstraint("Name", "John Doe"));

            pool.AddRule(rule);

            var data = new Dictionary<string, object>();
            data["Name"] = null;

            var engine = new RuleEngine(pool);

            var rules = engine.Evaluate(data);

            Assert.AreEqual(0, rules.Count());

            pool.Clear();
        }
    }
}