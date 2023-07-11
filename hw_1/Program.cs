using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "������� �������� ��� � ����������. �� ������ ������� �� /customs_duty ��� ������� ���������� �������" +
"��� �� /date_time ��� ��������� ������� ���� � ������� � ������ ������� �� ��������� ���� �����");

/*���������� ������� ��� ���������� �� ��������� (/customs_duty), ������� ����� ��������� ������ ���������� �������: 
 � ��������� price ���������� ��������� �������. ������� ����������� ��� ���������� 200�, � �� ������ ����� 15% 
 �� ����� ����������. */
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

/*���������� ��������, ������� ����� ���������� ������� ���� � ����� � ������ ������� (������� �������� ��� ������ 
� ������), �� �����, ���������� � ��������� language. �������� language ���������� � ������� ISO 639-1 (ru, en, 
fr, cn � �. �.).*/

app.MapGet("/date_time", (string language) => GetDateTime(language));

string GetDateTime(string language)
{
    CultureInfo culture = CultureInfo.GetCultureInfo(language);

    DateTime currentDate = DateTime.Now;
    string formattedDate = currentDate.ToString("F", culture);
    return formattedDate;
}

app.Run();