/*--------------------------------------------------------------
*				HTBLA-Leonding / Class: 1xHIF
*--------------------------------------------------------------
*              Musterlösung-HA
*--------------------------------------------------------------
* Description: UpdateProductCsv - UnitTests
*--------------------------------------------------------------
*/

namespace UnitTest;

using System;
using System.IO;
using System.Linq;

using FluentAssertions;

using Xunit;

using UpdateProductCsv;

public class UpdateProductCsvTests
{
    [Fact]
    public void T01_CheckArg_WrongCount()
    {
        UpdateProductCsv.Main(new string[0]).Should().Be(1);
        UpdateProductCsv.Main(new string[1]).Should().Be(1);
        UpdateProductCsv.Main(new string[3]).Should().Be(1);
    }

    [Fact]
    public void T02_CheckArg_NoFile()
    {
        UpdateProductCsv.Main(new string[] { "NoCSVFile", "5" }).Should().Be(1);
        UpdateProductCsv.Main(new string[] { "NoCSVFile.txt", "5" }).Should().Be(1);
    }

    [Fact]
    public void T03_UpdateCsv()
    {
        var fileName    = "Products.csv";
        var csvImporter = new CsvImport<Product>();

        var fileInfoOrig = new FileInfo(fileName).LastWriteTime;

        var products = csvImporter.Read(fileName);

        UpdateProductCsv.Main(new[] { fileName, "1.5" }).Should().Be(0);

        var fullPathName = Path.GetFullPath(fileName);
        var pathName     = $"{Path.GetDirectoryName(fullPathName)}\\";
        var bakPathName  = $"{pathName}{Path.GetFileNameWithoutExtension(fullPathName)}.bak";

        var fileInfoBak = new FileInfo(bakPathName).LastWriteTime;

        fileInfoOrig.Should().Be(fileInfoBak, "You have to rename the file to bak.");

        var productUpdated = csvImporter.Read(fileName);

        products.Should().HaveCount(productUpdated.Count);

        var mergedProducts = products.Join(productUpdated, p => p.ProductCode, p => p.ProductCode, (productOrig, productUpd) => (productOrig, productUpd));

        foreach (var mergedProduct in mergedProducts)
        {
            mergedProduct.productOrig.Description.Should().Be(mergedProduct.productUpd.Description);
            mergedProduct.productOrig.TaxClass.Should().Be(mergedProduct.productUpd.TaxClass);
            mergedProduct.productUpd.Retail.Should().Be((decimal)Math.Round((double)mergedProduct.productOrig.Retail * 1.015,2));
        }
    }
}