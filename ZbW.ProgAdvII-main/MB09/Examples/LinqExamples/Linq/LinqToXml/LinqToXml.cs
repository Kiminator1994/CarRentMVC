using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Linq.LinqToXml {
    public class LinqToXml {
        public static void Execute() {

            // Load the XML file from our project directory containing the purchase orders
            var filename = "PurchaseOrder.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, "LinqToXml", filename);

            XElement purchaseOrder = XElement.Load($"{purchaseOrderFilepath}");

            IEnumerable<XElement> pricesByPartNos =  from item in purchaseOrder.Descendants("Item")
                where (int) item.Element("Quantity") * (decimal) item.Element("USPrice") > 100
                orderby (string)item.Element("PartNumber")
                select item;

            foreach (XElement item in pricesByPartNos) {
                Console.WriteLine(item);
            }


            pricesByPartNos = purchaseOrder.Descendants("Item")
                .Where(item => (int)item.Element("Quantity") * (decimal)item.Element("USPrice") > 100)
                .OrderBy(order => order.Element("PartNumber"));

            foreach (XElement item in pricesByPartNos) {
                Console.WriteLine(item);
            }
        }
    }
}
