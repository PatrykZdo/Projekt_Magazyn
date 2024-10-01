//using CarScrapyardWarehouse.Client.Interfaces;
//using CarScrapyardWarehouse.Shared.Models;

//namespace CarScrapyardWarehouse.Client.Services
//{
//    public class CarService : ICarService
//    {
//        private readonly IHttpService _httpService;

//        public CarService(IHttpService httpService)
//        {
//            _httpService = httpService ?? throw new ArgumentNullException(nameof(httpService));
//        }

//        public async Task<List<Car>> GetAllCars()
//        {
//            return await _httpService.Get<List<Car>>("api/Car/cars");
//        }

//        public async Task<Car> GetCarById(int carId)
//        {
//            return await _httpService.Get<Car>($"api/Car/car/{carId}");
//        }

//        public async Task<string> AddCar(Car car)
//        {
//            var response = await _httpService.Post("api/Car/addCar", car);

//            if (response.IsSuccessStatusCode)
//            {
//                return "Car added successfully.";
//            }
//            else
//            {
//                return $"Error: {response.ReasonPhrase}";
//            }
//        }

//        public async Task<string> UpdateCar(Car updatedCar)
//        {
//            var response = await _httpService.Put("api/Car/updateCar", updatedCar);

//            if (response.IsSuccessStatusCode)
//            {
//                return "Car updated successfully.";
//            }
//            else
//            {
//                return $"Error: {response.ReasonPhrase}";
//            }
//        }

//        public async Task<string> RemoveCar(int carId)
//        {
//            var response = await _httpService.Delete($"api/Car/removeCar/{carId}");

//            if (response.IsSuccessStatusCode)
//            {
//                return "Car removed successfully.";
//            }
//            else
//            {
//                return $"Error: {response.ReasonPhrase}";
//            }
//        }
//    }
//}
