using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachFileReader
    {
        public Dictionary<string, List<VendingItems>> ReadInventory(string filePath)
        {
            Dictionary<string, List<VendingItems>> result = new Dictionary<string, List<VendingItems>>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string inputLine = sr.ReadLine();

                        string[] currentLine = inputLine.Split(new char[] { '|' });

                        List<VendingItems> listOfNameAndCosts = new List<VendingItems>();

                        if (currentLine[0].Contains("A"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                listOfNameAndCosts.Add(new Chips(currentLine[1], Decimal.Parse(currentLine[2])));
                            }
                        }
                        else if (currentLine[0].Contains("B"))
                        {
                            for(int i = 0; i < 5; i++)
                            {
                                listOfNameAndCosts.Add(new Candy(currentLine[1], Decimal.Parse(currentLine[2])));
                            }
                        }
                        else if (currentLine[0].Contains("C"))
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                listOfNameAndCosts.Add(new Drinks(currentLine[1], Decimal.Parse(currentLine[2])));
                            }
                        }
                        else
                        {
                            for(int i = 0; i < 5; i++)
                            {
                                listOfNameAndCosts.Add(new Gum(currentLine[1], Decimal.Parse(currentLine[2])));
                            }
                        }
                        result.Add(currentLine[0], listOfNameAndCosts);
                    }
                    return result;
                }
            }
            catch (IOException e1)
            {
                Console.WriteLine(e1.Message);
                return null;
            }
            catch (Exception e2)
            {
                Console.WriteLine(e2.Message);
                return null;
            }
        }
    }
}