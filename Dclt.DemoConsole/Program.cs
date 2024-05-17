// See https://aka.ms/new-console-template for more information
using Dclt.Shared.Extensions;
using Dclt.Shared.Helpers;

var qua = Dias.qua;

Console.WriteLine(qua.GetDescription());
Console.WriteLine(qua.GetValue());


var dias = EnumHelper.GetList<Dias>();
foreach (var dia in dias)
{
    Console.WriteLine($"{dia.Id} - {dia.Text}");
}

enum Dias
{
    dom,
    seg,
    ter,
    qua,
    qui,
    sex,
    sab
}