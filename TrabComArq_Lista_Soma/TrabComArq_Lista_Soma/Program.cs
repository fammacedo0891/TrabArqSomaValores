using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;
using TrabComArq_Lista_Soma.Entities;

namespace TrabComArq_Lista_Soma
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * instanciando o arq
             */

            string verArq = @"F:\Fernando\Curso\c#\Sistemas\TrabComArq_Lista_Soma\ListaProd.csv";


            try
            {

                // cria uma matriz para receber as info do VerArq

                string[] lines = File.ReadAllLines(verArq);

                // captura o endereco do arq

                string sourceFolderPath = Path.GetDirectoryName(verArq);

                // add a pasta out dentro do sourceFolderPath

                string targetFolderPath = sourceFolderPath + @"\out";

                // add o arq summary.csv dentro do targetFolderPath

                string targetFilePath = targetFolderPath + @"\summary.csv";

                // cria a pasta do info no targetFolderPath

                Directory.CreateDirectory(targetFolderPath);

                /*
                 * abre a instanciamento do arq e depois fecha no termino
                 * instancia p targetFilePath 
                 */

                using (StreamWriter sw = File.AppendText(targetFilePath))
                {
                    foreach (string line in lines)
                    {

                        // cria uma matriz para receber a leitura do arq separando os itens pelo caracter ','
                        string[] fields = line.Split(',');
                        // atribui o name o valor 0 da matriz
                        string name = fields[0];
                        // atribui o price o valor 1 da matriz
                        double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        // atribui a quant o valor 2 da matriz
                        int quantity = int.Parse(fields[2]);


                        //atribui o valor para a instancia do Produto
                        Produto prod = new Produto(name, price, quantity);

                        sw.WriteLine(prod.Name + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }


            catch (IOException e)
            {
                Console.WriteLine("Erro");
                Console.WriteLine(e.Message);
            }
        }
    }
}


