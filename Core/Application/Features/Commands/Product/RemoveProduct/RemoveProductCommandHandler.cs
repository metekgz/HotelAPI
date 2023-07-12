﻿using Application.Features.Commands.Product.UpdateProduct;
using Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Commands.Product.RemoveProduct
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly ILogger<RemoveProductCommandHandler> _logger;

        public RemoveProductCommandHandler(IProductWriteRepository productWriteRepository, ILogger<RemoveProductCommandHandler> logger)
        {
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }

        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            await _productWriteRepository.RemoveAsync(request.Id);
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product Silindi");
            return new();
        }
    }
}
