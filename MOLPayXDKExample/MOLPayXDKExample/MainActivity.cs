﻿using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MOLPayXDKExample;
using Newtonsoft.Json;

namespace MainActivity
{
    [Activity(Label = "MOLPayXDKExample", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == MOLPayActivity.MOLPayXDK && resultCode == Result.Ok)
            {
                Console.WriteLine("MOLPay result = " + data.GetStringExtra(MOLPayActivity.MOLPayTransactionResult));
                SetContentView(Resource.Layout.layout_molpay);
                TextView tw = (TextView)FindViewById(Resource.Id.resultTV);
                tw.Text = data.GetStringExtra(MOLPayActivity.MOLPayTransactionResult);
            }
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Dictionary<string, object> paymentDetails = new Dictionary<string, object>();
            paymentDetails.Add(MOLPayActivity.mp_amount, "1.10");
            paymentDetails.Add(MOLPayActivity.mp_username, "SB_molpayxdk");
            paymentDetails.Add(MOLPayActivity.mp_password, "cT54#Lk@22");
            paymentDetails.Add(MOLPayActivity.mp_merchant_ID, "SB_molpayxdk");
            paymentDetails.Add(MOLPayActivity.mp_app_name, "molpayxdk");
            paymentDetails.Add(MOLPayActivity.mp_order_ID, "20200223082350");
            paymentDetails.Add(MOLPayActivity.mp_currency, "MYR");
            paymentDetails.Add(MOLPayActivity.mp_country, "MY");
            paymentDetails.Add(MOLPayActivity.mp_verification_key, "4445db44bdb60687a8e7f7903a59c3a9"); //1736e565eb5c24483ea607a253e75817
            paymentDetails.Add(MOLPayActivity.mp_channel, "multi");
            paymentDetails.Add(MOLPayActivity.mp_bill_description, "description");
            paymentDetails.Add(MOLPayActivity.mp_bill_name, "hisyam adzha");
            paymentDetails.Add(MOLPayActivity.mp_bill_email, "hisyamadzha@gmail.com");
            paymentDetails.Add(MOLPayActivity.mp_bill_mobile, "+60176669401");
            paymentDetails.Add(MOLPayActivity.mp_channel_editing, false);
            paymentDetails.Add(MOLPayActivity.mp_editing_enabled, false);
            paymentDetails.Add(MOLPayActivity.mp_dev_mode, true);
            //paymentDetails.Add(MOLPayActivity.mp_is_escrow, "");
            //paymentDetails.Add(MOLPayActivity.mp_transaction_id, "");
            //paymentDetails.Add(MOLPayActivity.mp_request_type, "");
            //string[] binlock = new string[] { "", "" };
            //paymentDetails.Add(MOLPayActivity.mp_bin_lock, binlock);
            //paymentDetails.Add(MOLPayActivity.mp_bin_lock_err_msg, "");
            //paymentDetails.Add(MOLPayActivity.mp_custom_css_url, "file:///android_asset/custom.css");
            //paymentDetails.Add(MOLPayActivity.mp_preferred_token, "");
            //paymentDetails.Add(MOLPayActivity.mp_tcctype, "");
            //paymentDetails.Add(MOLPayActivity.mp_is_recurring, false);
            //paymentDetails.Add(MOLPayActivity.mp_sandbox_mode, true);
            //string[] allowedChannels = new string[] { "", "" };
            //paymentDetails.Add(MOLPayActivity.mp_allowed_channels, allowedChannels);
            //paymentDetails.Add(MOLPayActivity.mp_express_mode, false);
            //paymentDetails.Add(MOLPayActivity.mp_advanced_email_validation_enabled, false);
            //paymentDetails.Add(MOLPayActivity.mp_advanced_phone_validation_enabled, false);
            //paymentDetails.Add(MOLPayActivity.mp_bill_name_edit_disabled, true);
            //paymentDetails.Add(MOLPayActivity.mp_bill_email_edit_disabled, true);
            //paymentDetails.Add(MOLPayActivity.mp_bill_mobile_edit_disabled, true);
            //paymentDetails.Add(MOLPayActivity.mp_bill_description_edit_disabled, true);

            Intent intent = new Intent(this, typeof(MOLPayActivity));
            intent.PutExtra(MOLPayActivity.MOLPayPaymentDetails, JsonConvert.SerializeObject(paymentDetails));
            StartActivityForResult(intent, MOLPayActivity.MOLPayXDK);
        }
    }
}