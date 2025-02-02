﻿using Microsoft.AspNetCore.Mvc;
using Web_proj_Backend.Data;
using Web_proj_Backend.Data.Interfaces;
using Web_proj_Backend.Domain;
using Web_proj_Backend.Models;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Controllers
{
    [Route("api/[controller]")]
    public class AuthorizeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;

        public AuthorizeController(
            IUserRepository userRepository,
            DataContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        #region GET
        [HttpGet(nameof(UserExitById))]
        public IActionResult UserExitById([FromQuery]int userId)
        {
            var user = _userRepository.GetById(userId);
            if (user == null)
                return Ok(new { success = false, message = "Не удается найти пользователя" });

            user.Token = null;
            _context.SaveChanges();
            return Ok(new { success = true, message = "Пользователь успешно вышел" });
        }
        [HttpGet(nameof(UserExitByToken))]
        public IActionResult UserExitByToken([FromQuery]string token)
        {
            var user = _userRepository.GetByToken(token);
            if (user == null)
                return Ok(new { success = false, message = "Не удается найти пользователя" });

            user.Token = null;
            _context.SaveChanges();
            return Ok(new { success = true, message = "Пользователь успешно вышел" });
        }
        #endregion
        #region POST
        [HttpPost(nameof(Registration))]
        public IActionResult Registration([FromBody] UsersVM userVm)
        {
            if (string.IsNullOrEmpty(userVm.Login) || string.IsNullOrEmpty(userVm.Password))
                return Ok(new {success = false, message = "Недопустимый формат"});
            

            var user = new Users
            {
                Login = userVm.Login,
                Password = Crypt.GenerateHashPassword(userVm.Password),
                Address = userVm.Address,
                Email = userVm.Email,
                Full_name = userVm.Full_name,
                Phone = userVm.Phone,
                Money = 0,
                Token = Crypt.GenerateToken(userVm.Login)
            };
            _userRepository.Add(user);
            return Ok(new {success = true, message = "Пользователь зарегистрирован", token = user.Token});
        }

        [HttpPost(nameof(Authorize))]
        public IActionResult Authorize([FromBody] Users userVm)
        {
            var user = _userRepository.GetByLogin(userVm.Login);
            if (userVm == null || string.IsNullOrEmpty(userVm.Login) || string.IsNullOrEmpty(userVm.Password))
                return Ok(new {success = false, message = "Неверные данные"});

            if (user == null || user.Password != Crypt.GenerateHashPassword(userVm.Password))
                return Ok(new {success = false, message = "Неверный логин или пароль"});


            user.Token = Crypt.GenerateToken(user.Login);
            _context.SaveChanges();
            return Ok(new {success = true, message = "Пользователь авторизирован.", token = user.Token });
        }
        #endregion

    }
}