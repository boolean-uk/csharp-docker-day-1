using api_cinema_challenge.DTO;
using api_cinema_challenge.Models;
using api_cinema_challenge.Repository;
using api_cinema_challenge.Response;
using AutoMapper;

namespace api_cinema_challenge.Endpoints
{
    public static class CustomerEndpoints
    {
        public static void ConfigureCustomerEndpoints(this WebApplication app)
        {
            var movieGroup = app.MapGroup("/customers");

            movieGroup.MapGet("/", GetCustomers);
            movieGroup.MapPost("/", AddCustomer);
            movieGroup.MapPut("/{id}", UpdateCustomer);
            movieGroup.MapDelete("/{id}", DeleteCustomer);
        }

        public static async Task<IResult> GetCustomers(IRepository<Customer> repo, IMapper mapper)
        {
            var customer = await repo.Get();

            return Results.Ok(new Response<List<CustomerDTO>>("Success",(mapper.Map<List<CustomerDTO>>(customer))));

        }

        public static async Task<IResult> AddCustomer(IRepository<Customer> repo, CustomerPost customer, IMapper mapper)
        {
            Customer newCustomer = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Phone = customer.Phone,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            var result = await repo.Add(newCustomer);
            return Results.Ok(new Response<CustomerDTO>("Success", mapper.Map<CustomerDTO>(result)));
        }

        public static async Task<IResult> UpdateCustomer(IRepository<Customer> repo, int id, CustomerPost customer, IMapper mapper)
        {
            var existingCustomer = await repo.GetById(id);
            if (existingCustomer == null)
            {
                return Results.NotFound();
            }
            existingCustomer.Name = customer.Name;
            existingCustomer.Email = customer.Email;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.UpdatedAt = DateTime.Now;
            var result = await repo.Update(existingCustomer);

            return Results.Ok(new Response<CustomerDTO>("Success", mapper.Map<CustomerDTO>(result)));
        }

        public static async Task<IResult> DeleteCustomer(IRepository<Customer> repo, int id, IMapper mapper)
        {
            var existingCustomer = await repo.GetById(id);
            if (existingCustomer == null)
            {
                return Results.NotFound();
            }
            var result = await repo.Delete(id);
            return Results.Ok(new Response<CustomerDTO>("Success", mapper.Map<CustomerDTO>(result)));
        }

    }
}

