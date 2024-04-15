using ClosedXML.Excel;


namespace Controllers {

    public static class GerarExcel
    {

        public static byte[] GerarExcelLocal(List<Models.CepModel> local)
        {
            using (var workbook = new XLWorkbook())
            {
                
                var worksheet = workbook.Worksheets.Add("Local");

                worksheet.Cell("A1").Value = "CEP";
                worksheet.Cell("B1").Value = "Logradouro";
                worksheet.Cell("C1").Value = "Complemento";
                worksheet.Cell("D1").Value = "Bairro";
                worksheet.Cell("E1").Value = "Localidade";
                worksheet.Cell("F1").Value = "UF";
                worksheet.Cell("G1").Value = "GIA";
                worksheet.Cell("H1").Value = "DDD";
                worksheet.Cell("I1").Value = "SIAFI";

                for (int i = 0; i < local.Count; i++)
                {
                    worksheet.Cell(i + 2, 1).Value = local[i].cep;
                    worksheet.Cell(i + 2, 2).Value = local[i].logradouro;
                    worksheet.Cell(i + 2, 3).Value = local[i].complemento;
                    worksheet.Cell(i + 2, 4).Value = local[i].bairro;
                    worksheet.Cell(i + 2, 5).Value = local[i].localidade;
                    worksheet.Cell(i + 2, 6).Value = local[i].uf;
                    worksheet.Cell(i + 2, 7).Value = local[i].gia;
                    worksheet.Cell(i + 2, 8).Value = local[i].ddd;
                    worksheet.Cell(i + 2, 9).Value = local[i].siafi;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
                
            }




        }

    }

}
