using WebApplication2.Domain;
using Xunit;
using System.Collections.Generic;
using WebApplication2.Infrastructure.Repository;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using System;

namespace TestProject1
{

    public class InCsvFileOrderRepositoryIntegrationTest
    {

        [Fact]
        public void itCanSaveOrders()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };
            var lines = File.ReadAllLines(@"C:\Users\Biplop\source\repos\WebApplication2\TestProject1\testingFile.csv");

            List<OrderLine> orderLines = new List<OrderLine>();

            string hola="d";

            foreach(var line in lines)
            {
                var values = line.Split(",");
                orderLines.Add(new OrderLine(Int16.Parse(values[1]), Int16.Parse(values[2]), Convert.ToDouble(values[0])));
                hola = values[3];
            }

            Assert.True(orderLines[0].getCookieId() == 1);
            Assert.True(orderLines[0].getQuantity() == 2);
            Assert.True(orderLines[0].getTotalPrice() == 52.8725945);
            Assert.True(hola=="30.3");
        }

        [Fact]
        public void test2()
        {
            var csvConfig = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = false
            };
            var lines = File.ReadAllLines(@"C:\Users\Biplop\source\repos\WebApplication2\TestProject1\testingFile2.csv");

            List<OrderLine> orderLines = new List<OrderLine>();

            //string hola;
            double amount;
            foreach (var line in lines)
            {
                var values = line.Split(";");
               
                amount = Convert.ToDouble(values[0]);
            }

           // Assert.True(hola == "30.3");
            Assert.True(amount == 1);
        }
    }
}