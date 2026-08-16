using Mahalak;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mahalak;
public class PConditionConfiguration : IEntityTypeConfiguration<PCondition>
{
    public void Configure(EntityTypeBuilder<PCondition> builder)
    {
        var conditions=new List<PCondition>
        {
           new PCondition{Id=1,Name="جديد"},
           new PCondition{Id=2,Name="مستعمل"}
        };
        builder.HasData(conditions);
    }
}
