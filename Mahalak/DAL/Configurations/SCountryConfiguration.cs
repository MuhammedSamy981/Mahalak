using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class SCountryConfiguration : IEntityTypeConfiguration<SCountry>
{
    public void Configure(EntityTypeBuilder<SCountry> builder)
    {
        var countries=new List<SCountry>
        {
           new SCountry{Id=1,Name="EGYPT",Currency = "جنيه مصري" },  
           new SCountry{Id=2,  Name="SAUDI ARABIA",  Currency = "ريال سعودي" }, 
           new SCountry{Id=3,  Name="UAE",  Currency = "درهم إماراتي" }, 
           new SCountry{Id=4,  Name="KUWAIT",  Currency = "دينار كويتي" },
           new SCountry{Id=5,  Name="QATAR",  Currency = "ريال قطري" }, 
           new SCountry{Id=6,  Name="BAHRAIN",  Currency = "دينار بحريني" }, 
           new SCountry{Id=7,  Name="OMAN",  Currency = "ريال عماني" },  
           new SCountry{Id=8,  Name="JORDAN",  Currency = "دينار أردني" },
           new SCountry{Id=9,  Name="IRAQ",  Currency = "دينار عراقي" },
           new SCountry{Id=10, Name="SYRIA", Currency = "ليرة سورية"}, 
           new SCountry{Id=11, Name="LEBANON", Currency = "ليرة لبنانية"},
           new SCountry{Id=12, Name="PALESTINE", Currency = "شيكل فلسطيني" },
           new SCountry{Id=13, Name="LIBYA", Currency = "دينار ليبي" },
           new SCountry{Id=14, Name="TUNISIA", Currency = "دينار تونسي" }, 
           new SCountry{Id=15, Name="ALGERIA", Currency = "دينار جزائري" },
           new SCountry{Id=16, Name="MOROCCO", Currency = "درهم مغربي" }, 
           new SCountry{Id=17, Name="SUDAN", Currency = "جنيه سوداني" }, 
           new SCountry{Id=18, Name="YEMEN", Currency = "ريال يمني" }, 
           new SCountry{Id=19, Name="MAURITANIA", Currency = "أوقية موريتانية" },
           new SCountry{Id=20, Name="SOMALIA", Currency = "شلن صومالي" },   
           new SCountry{Id=21, Name="COMOROS", Currency = "فرنك قمري" },   
           new SCountry{Id=22, Name="DJIBOUTI", Currency = "فرنك جيبوتي"}
        };
        builder.HasData(countries);
    }
}
