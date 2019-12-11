using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;

namespace BotMegaSenaHtml
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe o número do concurso");
            string numeroDoConcurso = Console.ReadLine();

            if (string.IsNullOrEmpty(numeroDoConcurso))
            {
                numeroDoConcurso = "2103";
            }
            string url = @"http://loterias.caixa.gov.br/wps/portal/loterias/landing/megasena/!ut/p/a1/04_Sj9CPykssy0xPLMnMz0vMAfGjzOLNDH0MPAzcDbwMPI0sDBxNXAOMwrzCjA0sjIEKIoEKnN0dPUzMfQwMDEwsjAw8XZw8XMwtfQ0MPM2I02-AAzgaENIfrh-FqsQ9wNnUwNHfxcnSwBgIDUyhCvA5EawAjxsKckMjDDI9FQE-F4ca/dl5/d5/L2dBISEvZ0FBIS9nQSEh/pw/Z7_HGK818G0KO6H80AU71KG7J0072/res/id=buscaResultado/c=cacheLevelPage/=/?timestampAjax=1576026082688&concurso=2103";
            string html;


            using (WebClient wc = new WebClient())
            {
                wc.Headers["Cookie"] = "security=true";
                html = wc.DownloadString(url);
            }

            html = html.Replace("{", "");
            html = html.Replace("}", ""); 
            html = html.Replace("\"", "");
           

            string[] vet = Regex.Split(html, ",");
            List<string> resultado = new List<string>();

            resultado.Add(vet[1].ToString());
            resultado.Add(vet[2].ToString());
            resultado.Add(vet[3].ToString());
            resultado.Add(vet[4].ToString());
            resultado.Add(vet[5].ToString());

            Console.WriteLine("Consurso selecionado:" + numeroDoConcurso);
            Console.WriteLine(resultado[0]);
            Console.WriteLine(resultado[1]);
            Console.WriteLine(resultado[2]);


            Console.ReadKey();
        }
    }
}
