﻿using Api_Hitss.Model;

namespace Api_Hitss.Interface
{
    public interface IPaymentFlowSummaryRepository
    {
        PaymentFlowSummary Create(PaymentFlowSummary paymentFlowSummary);
        //PaymentFlowSummary Detalhe();
    }
}
