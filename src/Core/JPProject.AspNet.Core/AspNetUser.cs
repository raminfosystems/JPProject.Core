﻿using IdentityModel;
using JPProject.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Security.Claims;
using JPProject.Domain.Core.Util;

namespace JPProject.AspNet.Core
{
    public class AspNetUser : ISystemUser
    {
        private readonly IHttpContextAccessor _accessor;

        public AspNetUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public string Username => GetUsername();

        private string GetUsername()
        {
            var username = _accessor.HttpContext.User.FindFirst("username")?.Value;
            if (username.IsPresent()) return username;

            username = _accessor.HttpContext.User.FindFirst(JwtClaimTypes.Name)?.Value;
            if (username.IsPresent()) return username;

            username = _accessor.HttpContext.User.FindFirst(JwtClaimTypes.GivenName)?.Value;
            if (username.IsPresent()) return username;

            username = _accessor.HttpContext.User.Identity.Name;
            if (username.IsPresent()) return username;

            var sub = _accessor.HttpContext.User.FindFirst(JwtClaimTypes.Subject);
            if (sub != null) return sub.Value;

            return string.Empty;
        }

        public string UserId => _accessor.HttpContext.User.FindFirst(JwtClaimTypes.Subject)?.Value;
        public bool IsAuthenticated()
        {
            return _accessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public bool IsInRole(string role)
        {
            return _accessor.HttpContext.User.IsInRole(role);
        }

        public IEnumerable<Claim> GetClaimsIdentity()
        {
            return _accessor.HttpContext.User.Claims;
        }

        public string GetRemoteIpAddress()
        {
            return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
        public string GetLocalIpAddress()
        {
            return _accessor.HttpContext.Connection.LocalIpAddress.ToString();
        }
    }
}
