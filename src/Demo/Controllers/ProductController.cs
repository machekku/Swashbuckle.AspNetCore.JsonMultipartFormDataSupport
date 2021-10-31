﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport;
using Swashbuckle.AspNetCore.JsonMultipartFormDataSupport.Models;

namespace Demo.Controllers {
	[Produces("application/json")]
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase {
		private readonly ILogger<ProductController> _logger;

		public ProductController(ILogger<ProductController> logger) {
			_logger = logger;
		}

		[HttpPost]
		public IActionResult Post([FromForm] MultipartFormData<Product> data) {
			var json = data.Json ?? throw new NullReferenceException(nameof(data));
			var image = data.File;
			return Ok();
		}

		[HttpPost("wrapper")]
		public IActionResult PostWrapper([FromForm] ProductWrapper wrapper) {
			var wrapperProduct = wrapper.Product?? throw new NullReferenceException(nameof(wrapper.Product));
			var image = wrapper.Files;
			return Ok();
		}
	}
}
