using System;
using System.Collections.Generic;
using NUnit.Framework;
using Vji.Mvc;
using Vji.NUnit.Std.Test;
using Vji.Mock.Mvc;

namespace Vji.Mvc {
    
    [TestFixture]
    public class PreAndPostCommandsInputDecoratorImplTest : Vji.Mvc.TestCaseImpl {
        
        [Test]
        public void TestNext_WithPrePopulatedStartCommands() {
            
            IList<Command> preCommands = new List<Command>();
            preCommands.Add(this.MvcFactory.NewStartCommand());
            
            IList<Command> postCommands = new List<Command>();
            postCommands.Add(this.MvcFactory.NewFinishCommand());
            
            IList<Command> commands = new List<Command>();
            commands.Add(this.MockMvcFactory.NewMockCommand("a mock command"));
                
            Input input = this.MockMvcFactory.NewMockInput();
            
            Input decoratedInput = this.MvcFactory.NewPreAndPostCommandsInputDecorator(
                input,
                preCommands,
                postCommands
            );


            Command command = decoratedInput.Next();
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(StartCommand)));
            
            command = decoratedInput.Next();
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(MockCommand)));
            MockCommand mockCommand = (MockCommand) command;
            Assert.That(mockCommand.Message, Is.EqualTo("a mock command"));

            command = decoratedInput.Next();
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf(typeof(FinishCommand)));
            
            command = input.Next();
            Assert.That(command, Is.Null);
        }
    }
}
