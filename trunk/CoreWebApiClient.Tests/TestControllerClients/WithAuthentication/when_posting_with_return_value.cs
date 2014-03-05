﻿using CoreWebApiClient.TestControllers;
using NUnit.Framework;

namespace CoreWebApiClient.Tests.TestControllerClients.WithAuthentication
{
    [TestFixture]
    public class when_posting_with_return_value : TestControllerClientWithAuthenticationSetup
    {
        private AnotherTestDto _dto;
        const int Id = 23;
        const string Name = "name";
        const string Value = "value";

        protected override void Act()
        {
            _dto = ControllerClient.PostWithReturnValue(new TestDto { Id = Id, Name = Name }, Value);
        }

        [Test]
        public void post_with_return_value()
        {
            Act();

            Assert.That(_dto.Id, Is.EqualTo(Id));
            Assert.That(_dto.Name, Is.EqualTo(Name));
            Assert.That(_dto.Value, Is.EqualTo(Value));
        }
    }
}