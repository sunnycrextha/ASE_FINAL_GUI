using System;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ASE_Assignment_2020;

namespace UnitTestProject_ASE
{
    [TestClass]
    public class Unit_Testing_Form1
    {
        [TestMethod]
        public void button1_click_myCommand_IsNullOrEmpty()
        {
            //Arrange
            string input;
            TextBox textbox = new TextBox();
            input = null;

            //Act
            Form1 form = new Form1();
            textbox.Text = input;

            //Assert
            string expectedOutCome;
            expectedOutCome = null;
            Assert.AreEqual(expectedOutCome, input);
        }
    }
}
