using api_cinema_challenge.DTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace api_cinema_challenge.Endpoints
{
    public static class TicketEndpoints
    {
        public static void ConfigureTicketEndpoints(this WebApplication app)
        {
            var ScreeningGroup = app.MapGroup("/movies");

            ScreeningGroup.MapGet("/{CustomerId}/screenings/{ScreeningsId}", GetTicket);
            ScreeningGroup.MapPost("/{CustomerId}/screenings/{ScreeningsId}", AddTicket);

        }

        public static async Task<IResult> GetTicket(IRepository<Ticket> ticketRepo, IRepository<Customer> customerRepo, IRepository<Screening> screenRepo,int customerId, int screenId, IMapper mapper)
        {

            Customer customer = await customerRepo.GetById(customerId);

            if (customer == null) return Results.NotFound();

            Screening screen = await screenRepo.GetById(screenId);
            if (screen == null) return Results.NotFound();

            List<Ticket> tickets = await ticketRepo.GetQuery()
                .Where(t => t.CustomerId == customerId)
                .Where(t => t.ScreeningId == screenId)
                .ToListAsync();


            return Results.Ok(mapper.Map<List<TicketDTO>>(tickets));

        }

        public static async Task<IResult> AddTicket(IRepository<Ticket> ticketRepo,IRepository<Screening> screenRepo, IRepository<Customer> customerRepo,
                                                    TicketPost ticket, int customerId, int screenId, IMapper mapper)

        {
            Customer customer = await customerRepo.GetById(customerId);
            if (customer == null) return Results.NotFound();
            Screening screen = await screenRepo.GetById(screenId);
            if (screen == null) return Results.NotFound();
            Ticket newTicket = new Ticket
            {
                CustomerId = customer.Id,
                ScreeningId = screen.Id,
                NumSeats = ticket.NumSeats,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };
            var result = await ticketRepo.Add(newTicket);
            var ticketDto = mapper.Map<TicketDTO>(result);
            return Results.Ok(ticketDto);

        }
    }
}
