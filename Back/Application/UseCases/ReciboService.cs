using Application.DTOs.Request.Recibo;
using Application.DTOs.Response.Recibo;
using Application.Interfaces.Recibo;
using Domain.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Services
{
    public class ReciboService : IReciboService
    {
        private readonly IReciboCommand _command;
        private readonly IReciboQuery _query;

        public ReciboService(IReciboCommand command, IReciboQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<ReciboResponse> RegistrarRecibo(RegistrarReciboRequest request, CancellationToken ct = default)
        {
            var recibo = new Recibo
            {
                IdCobro = request.IdCobro,
                IdReserva = request.IdReserva,
                MontoTotal = request.MontoTotal,
                FechaEmision = request.FechaEmision
            };

            var resultado = await _command.RegistrarRecibo(recibo, ct);

            return new ReciboResponse
            {
                Id_Recibo = resultado.IdRecibo,
                Id_Cobro = resultado.IdCobro,
                Id_Reserva = resultado.IdReserva,
                MontoTotal = resultado.MontoTotal,
                FechaEmision = resultado.FechaEmision
            };
        }

        public async Task<ReciboResponse> ModificarRecibo(ModificarReciboRequest request, CancellationToken ct = default)
        {
            var reciboExistente = await _query.ConsultarRecibo(request.IdRecibo, ct);
            if (reciboExistente == null)
            {
                throw new Exception($"No se encontró el recibo con ID {request.IdRecibo}");
            }

            reciboExistente.IdCobro = request.IdCobro;
            reciboExistente.IdReserva = request.IdReserva;
            reciboExistente.MontoTotal = request.MontoTotal;
            reciboExistente.FechaEmision = request.FechaEmision;

            var resultado = await _command.ModificarRecibo(reciboExistente, ct);

            return new ReciboResponse
            {
                Id_Recibo = resultado.IdRecibo,
                Id_Cobro = resultado.IdCobro,
                Id_Reserva = resultado.IdReserva,
                MontoTotal = resultado.MontoTotal,
                FechaEmision = resultado.FechaEmision
            };
        }

        public async Task<ReciboResponse> ConsultarRecibo(int idRecibo, CancellationToken ct = default)
        {
            var recibo = await _query.ConsultarRecibo(idRecibo, ct);
            if (recibo == null)
            {
                throw new Exception($"No se encontró el recibo con ID {idRecibo}");
            }

            return new ReciboResponse
            {
                Id_Recibo = recibo.IdRecibo,
                Id_Cobro = recibo.IdCobro,
                Id_Reserva = recibo.IdReserva,
                MontoTotal = recibo.MontoTotal,
                FechaEmision = recibo.FechaEmision
            };
        }

        public async Task<ReciboResponse> ImprimirRecibo(int idRecibo, CancellationToken ct = default)
        {
            // El diagrama pide Imprimir, usamos la consulta específica para traer el modelo listo para salida
            var recibo = await _query.ImprimirRecibo(idRecibo, ct);
            if (recibo == null)
            {
                throw new Exception($"No se pudo generar la impresión. No existe el recibo con ID {idRecibo}");
            }

            return new ReciboResponse
            {
                Id_Recibo = recibo.IdRecibo,
                Id_Cobro = recibo.IdCobro,
                Id_Reserva = recibo.IdReserva,
                MontoTotal = recibo.MontoTotal,
                FechaEmision = recibo.FechaEmision
            };
        }

        public async Task<bool> EliminarRecibo(EliminarReciboRequest request, CancellationToken ct = default)
        {
            var recibo = await _query.ConsultarRecibo(request.Id_Recibo, ct);
            if (recibo == null)
            {
                throw new Exception($"No se encontró el recibo a eliminar con ID {request.Id_Recibo}");
            }

            await _command.EliminarRecibo(recibo, ct);
            return true;
        }
    }
}