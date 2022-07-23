﻿using System;
using Mc2.CrudTest.Framework;

namespace Mc2.CrudTest.Domain.Contracts.Events.Customers
{
    public record CustomerRemovedEvent(
        Guid Id,
        DateTime RemovedDateTime) : DomainEvent
    {
    }
}