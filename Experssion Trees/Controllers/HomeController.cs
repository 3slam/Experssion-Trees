using Experssion_Trees.Data;
using Experssion_Trees.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;


namespace Experssion_Trees.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  ApplicationDbContext _context;
        private  List<PassengerInfo> passengers = new();
        public HomeController(ILogger<HomeController> logger , ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
             passengers = _context.PassengerInfos.ToList();
 
            var viewModel = new PassengerViewModel
            {
                Passengers = passengers,
                Filter = new PassengerFilterViewModel()
            };
            return View(viewModel);
        }

         
        public IActionResult filterV1(PassengerFilterViewModel filter)
        {
             List<PassengerInfo> passengers = _context.PassengerInfos.ToList();
             
            if (filter.Survived!=null)
            {
                passengers = passengers.Where(x => x.Survived == filter.Survived).ToList();
            }

            if (filter.PClass.HasValue)
            {
                passengers = passengers.Where(x => x.PassengerClass == filter.PClass).ToList();
            }
            
            if (!string.IsNullOrEmpty(filter.Sex))
            {
                passengers = passengers.Where(x => x.Sex == filter.Sex).ToList();
            }

            if (filter.Age.HasValue)
            {
                passengers = passengers.Where(x => x.Age == filter.Age).ToList();
            }

            var viewModel = new PassengerViewModel
            {
                Passengers = passengers,
                Filter = new PassengerFilterViewModel()
            };
            return View(nameof(Index), viewModel);
        }


        public IActionResult filterV2(PassengerFilterViewModel filter)
        {
            Expression exp = Expression.Constant(true);
            ParameterExpression paramter = Expression.Parameter(typeof(PassengerInfo), "PassnerInfo");

            if (filter.Survived != null)
            {
                ConstantExpression survivedValue = Expression.Constant(filter.Survived);
                MemberExpression survivedProperty = Expression.Property(paramter, nameof(PassengerInfo.Survived));
                BinaryExpression survivedExp = Expression.Equal(survivedValue, survivedProperty);
                exp = Expression.AndAlso(exp, survivedExp);
            }

            if (filter.PClass.HasValue)
            {
                ConstantExpression pClassValue = Expression.Constant(filter.PClass);
                MemberExpression pClassProperty = Expression.Property(paramter, nameof(PassengerInfo.PassengerClass));
                BinaryExpression pClassExp = Expression.Equal(pClassValue, pClassProperty);
                exp = Expression.AndAlso(exp, pClassExp);
            }

            if (!string.IsNullOrEmpty(filter.Sex))
            {
                ConstantExpression sexValue = Expression.Constant(filter.Sex);
                MemberExpression sexProperty = Expression.Property(paramter, nameof(PassengerInfo.Sex));
                BinaryExpression sexExp = Expression.Equal(sexValue, sexProperty);
                exp = Expression.AndAlso(exp, sexExp);
            }

            if (filter.Age.HasValue)
            {
                ConstantExpression ageValue = Expression.Constant(filter.Age);
                MemberExpression ageProperty = Expression.Property(paramter, nameof(PassengerInfo.Age));
                BinaryExpression ageExp = Expression.Equal(ageValue, ageProperty);
                exp = Expression.AndAlso(exp, ageExp);
            }

            Expression<Func<PassengerInfo, bool>> finalExp = Expression.Lambda<Func<PassengerInfo, bool>>(exp, new List<ParameterExpression> { paramter });
            var passengers = _context.PassengerInfos.Where(finalExp.Compile()).ToList();
            var viewModel = new PassengerViewModel
            {
                Passengers = passengers,
                Filter = new PassengerFilterViewModel()
            };
            return View(nameof(Index), viewModel);
        }


    }
}
