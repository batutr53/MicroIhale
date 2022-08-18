using AutoMapper;
using EventBusRabbitMQ.Events;
using MicroIhale.Sourcing.Entities;

namespace MicroIhale.Sourcing.Mapping
{
    public class SourcingMapping : Profile
    {
        public SourcingMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
