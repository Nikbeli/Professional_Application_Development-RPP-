using FurnitureAssemblyContracts.BindingModels;
using FurnitureAssemblyContracts.BusinessLogicsContracts;
using FurnitureAssemblyContracts.SearchModels;
using FurnitureAssemblyContracts.ViewModels;
using FurnitureAssemblyDataModels.Enums;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureAssemblyBusinessLogic.BussinessLogic
{
    public class WorkModeling : IWorkProcess
    {
        private readonly ILogger _logger;

        private readonly Random _rnd;

        private IOrderLogic? _orderLogic;

        // Конструктор
        public WorkModeling(ILogger<WorkModeling> logger)
        {
            _logger = logger;
            _rnd = new Random(1000);
        }

        public void DoWork(IImplementerLogic implementerLogic, IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
            var implementers = implementerLogic.ReadList(null);

            if (implementers == null)
            {
                _logger.LogWarning("DoWork. Implementers is null");
                return;
            }

            var orders = _orderLogic.ReadList(new() { Status = OrderStatus.Принят });
            if (orders == null)
            {
                _logger.LogWarning("DoWork. Orders is null or empty");
                return;
            }

            _logger.LogDebug("DoWork for {count} orders", orders.Count);

            foreach (var implementer in implementers)
            {
                Task.Run(() => WorkerWorkAsync(implementer, orders));
            }
        }

        // Имитация работы исполнителя
        private async Task WorkerWorkAsync(ImplementerViewModel implementer, List<OrderViewModel> orders)
        {
            if (_orderLogic == null || implementer == null)
            {
                return;
            }

            await Task.Run(() =>
            {
                try
                {
                    var runOrder = _orderLogic.ReadList(new OrderSearchModel
                    {
                        ImplementerId = implementer.Id,
                        Status = OrderStatus.Ожидание
                    });

                    if (runOrder == null)
                    {
                        return;
                    }

                    foreach (var order in runOrder)
                    {
                        _logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, order.Id);
                        _orderLogic.FinishOrder(new OrderBindingModel
                        {
                            Id = order.Id
                        });
                    }
                }
                // Заказа может не быть, просто игнорируем ошибку
                catch (InvalidOperationException ex)
                {
                    _logger.LogWarning(ex, "Error try get work");
                }
                // Может возникнуть иная ошибка, тогда просто заканчиваем выполнение имитации
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error while do work");
                    throw;
                }
            });

            await RunOrderInWork(implementer);

            await Task.Run(() =>
            {
                foreach (var order in orders)
                {
                    try
                    {
                        _logger.LogDebug("DoWork. Worker {Id} try get order {Order}", implementer.Id, order.Id);

                        // Пытаемся назначить заказ на исполнителя
                        _orderLogic.TakeOrderInWork(new OrderBindingModel
                        {
                            Id = order.Id,
                            ImplementerId = implementer.Id
                        });

                        // Работу работаем, делаем-делаем
                        Thread.Sleep(implementer.WorkExperience * order.Count);

                        _logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, order.Id);

                        _orderLogic.FinishOrder(new OrderBindingModel
                        {
                            Id = order.Id
                        });

                        // Усёёё отдыхаем
                        Thread.Sleep(implementer.Qualification);
                    }

                    // Игнорируем ошибку, если с заказом что-то случится
                    catch (InvalidOperationException ex)
                    {
                        _logger.LogWarning(ex, "Error try get work");
                    }

                    // Заканчиваем выполнение имитации в случае иной ошибки
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error while do work");
                        throw;
                    }
                }
            });
        }

        // Ищем заказ, которые уже в работе (вдруг исполнителя прервали)
        private async Task RunOrderInWork(ImplementerViewModel implementer)
        {
            if (_orderLogic == null || implementer == null)
            {
                return;
            }

            try
            {
                var runOrder = await Task.Run(() => _orderLogic.ReadElement(new OrderSearchModel
                {
                    ImplementerId = implementer.Id,
                    Status = OrderStatus.Выполняется
                }));

                if (runOrder == null)
                {
                    return;
                }

                _logger.LogDebug("DoWork {Id} back to order {Order}", implementer.Id, runOrder.Id);

                // Доделываем работу
                Thread.Sleep(implementer.WorkExperience * runOrder.Count);

                _logger.LogDebug("DoWork. Worker {Id} finish order {Order}", implementer.Id, runOrder.Id);

                _orderLogic.FinishOrder(new OrderBindingModel
                {
                    Id = runOrder.Id
                });

                // Отдыхаем, хватит работы
                Thread.Sleep(implementer.Qualification);
            }

            // Заказа может не быть, просто игнорируем ошибку
            catch (InvalidOperationException ex)
            {
                _logger.LogWarning(ex, "Error try get work");
            }

            // Просто возникнет тупая ошибка, тогда заканчиваем выполнение имитации
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while do work");
                throw;
            }
        }
    }
}
