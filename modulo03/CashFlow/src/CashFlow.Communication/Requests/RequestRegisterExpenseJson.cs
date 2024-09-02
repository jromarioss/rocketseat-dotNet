﻿using CashFlow.Communication.Enums;

namespace CashFlow.Communication.Requests;
public class RequestRegisterExpenseJson
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public PaymentType PaymentType { get; set; }
    public DateTime Date { get; set; }
}
