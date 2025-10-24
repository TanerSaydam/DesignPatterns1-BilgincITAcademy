using TS.MediatR;

namespace _02CQRSPattern.Application;

public record ProductCreateCommandRequest(
    string Name,
    decimal Price) : IRequest;
