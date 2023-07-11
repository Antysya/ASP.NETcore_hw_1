using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "√лавна€ страница еще в разработке. ¬ы можете перейти на /customs_duty дл€ расчета таможенной пошлины" +
"или на /date_time дл€ просмотра текущей даты и времени в полном формате на указанном вами €зыке");

/*Ќеобходимо создать веб приложение со страницей (/customs_duty), котора€ будет вычисл€ть размер таможенной пошлины: 
 в параметре price передаетс€ стоимость посылки. ѕошлина начисл€етс€ при превышении 200И, а ее размер равен 15% 
 от суммы превышени€. */
app.MapGet("/customs_duty", (float price) => GetCustomsDuty(price));

float GetCustomsDuty(float price)
{
    float customsDuty = 0;
    if (price > 200)
    {
        float exceedingPrice = price - 200;
        customsDuty = (float)Math.Round(exceedingPrice * 0.15, 2);
    }

    return customsDuty;
}

/*–еализуйте страницу, котора€ будет показывать текущую дату и врем€ в полном формате (включа€ название дн€ недели 
и мес€ца), на €зыке, переданном в параметре language. ѕараметр language передаетс€ в формате ISO 639-1 (ru, en, 
fr, cn и т. д.).*/

app.MapGet("/date_time", (string language) => GetDateTime(language));

string GetDateTime(string language)
{
    CultureInfo culture = CultureInfo.GetCultureInfo(language);

    DateTime currentDate = DateTime.Now;
    string formattedDate = currentDate.ToString("F", culture);
    return formattedDate;
}

app.Run();