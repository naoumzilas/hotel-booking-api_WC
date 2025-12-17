using HotelBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Mappings
{
    public sealed class BookingModelMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Reference).IsRequired().HasMaxLength(50);

            builder.HasIndex(b => b.Reference).IsUnique();

            // Value object mapping
            builder.OwnsOne(b => b.Stay, stay =>
            {
                stay.Property(s => s.CheckIn).IsRequired();
                stay.Property(s => s.CheckOut).IsRequired();
            });
        }
    }
}
