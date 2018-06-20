/* 
 * Thirdwatch API
 *
 * The first version of the Thirdwatch API is an exciting step forward towards making it easier for developers to pass data to Thirdwatch.  Once you've [registered your website/app](https://thirdwatch.ai) it's easy to start sending data to Thirdwatch.  All endpoints are only accessible via https and are located at `api.thirdwatch.ai`. For instance: you can send event at the moment by ```HTTP POST``` Request to the following URL with your API key in ```Header``` and ```JSON``` data in request body. ```   https://api.thirdwatch.ai/event/v1 ``` Every API request must contain ```API Key``` in header value ```X-THIRDWATCH-API-KEY```  Every event must contain your ```_userId``` (if this is not available, you can alternatively provide a ```_sessionId``` value also in ```_userId```).  JavaScript Fingerprinting module for capturing unique devices and tracking user interaction.  This script will identify unique devices with respect to the browser. For e.g., if chrome is opened in normal mode a unique device id is generated and this will be same if chrome is opened in incognito mode or reinstalled.  Paste the below script onto your webpage, just after the opening `<body>` tag. This script should be added to the page which is accessed externally by the user of your website. For e.g., If you want to track three different webpages then paste the below script onto each webpage, just after the opening `<body>` tag. This script should not be added onto internal tools or admin panels. ```   &lt;script id=\"thirdwatch\"     data-session-cookie-name=\"&lt;cookie_name&gt;\"     data-session-id-value=\"&lt;session_id&gt;\"     data-user-id=\"&lt;user_id&gt;\"     data-app-secret=\"&lt;app_secret&gt;\"     data-is-track-pageview=\"true\"&gt; (function() {         var loadDeviceJs = function() {         var element = document.createElement(\"script\");         element.async = 1;         element.src = \"https://cdn.thirdwatch.ai/tw.min.js\";         document.body.appendChild(element);         };         if (window.addEventListener) {              window.addEventListener(\"load\", loadDeviceJs, false);         } else if (window.attachEvent) {         window.attachEvent(\"onload\", loadDeviceJs);         }     })();   &lt;/script&gt; ``` * `data-session-cookie-name` - - The cookie name where you are saving the unique session id. We will pick the session id by reading its value from the cookie name. (Optional) * `data-session-id-value` - - In case you are not passing `data-session-cookie-name` than you can put session id directly in this parameter. In absence of both `data-session-cookie-name` and `data-session-id-value`, our system will generate a session Id. (Optional) * `data-user-id` - - Unique user id at your end. This can be email id or primary key in the database. In case of guest user, you can insert session Id here. * `data-app-secret` - - Unique App secret generated for you by Thirdwatch. * `data-is-track-pageview` - - If this is set to true, then the url on which this script is running will be sent to Thirdwatch, else the url will not be captured.   The Score API is use to get an up to date cutomer trust score after you have sent transaction event and order successful. This API will provide the riskiness score of the order with reasons. Some examples of when you may want to check the score are before:    - Before Shippement of a package   - Finalizing a money transfer   - Giving access to a prearranged vacation rental   - Sending voucher on mail  ```   https://api.thirdwatch.ai/neo/v1/score?api_key=<your api key>&order_id=<Order id> ```  According to Score you can decide to take action Approve or Reject. Orders with score more than 70 will consider as Riskey orders. We'll provide some reasons also in rules section.   ``` {   \"order_id\": \"OCT45671\",   \"user_id\": \"ajay_245\",   \"order_timestamp\": \"2017-05-09T09:40:45.717Z\",   \"score\": 82,   \"flag\": \"red\",     -\"reasons\": [     {         \"name\": \"_numOfFailedTransactions\",         \"display_name\": \"Number of failed transactions\",         \"flag\": \"green\",         \"value\": \"0\",         \"is_display\": true       },       {         \"name\": \"_accountAge\",         \"display_name\": \"Account age\",         \"flag\": \"red\",         \"value\": \"0\",         \"is_display\": true       },       {         \"name\": \"_numOfOrderSameIp\",         \"display_name\": \"Number of orders from same IP\",         \"flag\": \"red\",         \"value\": \"11\",         \"is_display\": true       }     ] } ``` 
 *
 * OpenAPI spec version: 0.0.1
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using SwaggerDateConverter = ai.thirdwatch.Client.SwaggerDateConverter;

namespace ai.thirdwatch.Model
{
    /// <summary>
    /// The Promotion field type generically models different kinds of promotions such as referrals, coupons, free trials, etc. The value must be a nested JSON object which you populate with the appropriate information to describe the promotion. Not all sub-fields will likely apply to a given promotion. Populate only those that apply.  A promotion can be added when creating or updating an account, creating or updating an order, or on its own using the add_promotion event. The promotion object supports both monetary (e.g. 500 coupon on first order) and non-monetary (e.g. \&quot;100 in points to refer a friend\&quot;). 
    /// </summary>
    [DataContract]
    public partial class Promotion :  IEquatable<Promotion>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Promotion" /> class.
        /// </summary>
        /// <param name="promotionId">The ID/Coupon Code within your system that you use to represent this promotion. This ID is ideally unique to the promotion across users (e.g. \&quot;Welcome\&quot;)..</param>
        /// <param name="status">The status of the addition of promotion to an account. Best used with the add_promotion event. This way you can pass to Thirdwatch both successful and failed attempts when using a promotion. May be useful in spotting potential abuse. e.g. _success, _Failed.</param>
        /// <param name="description">Describe promotion here..</param>
        /// <param name="amount">The amount or credits the promotion is worth..</param>
        /// <param name="minPurchaseAmount">The minimum amount someone must spend in order for the promotion to be applied..</param>
        /// <param name="referrerUserId">The unique user ID of the user who referred the user to this promotion..</param>
        /// <param name="failureReason">When adding a promotion fails, use this to describe why it failed.e.g. _alreadyUsed, _invalidCode, _notApplicable, _expired.</param>
        /// <param name="percentageOff">The percentage discount. If the discount is 10% off, you would send \&quot;10\&quot;..</param>
        /// <param name="currencyCode">The [ISO-4217](http://en.wikipedia.org/wiki/ISO_4217) currency code for the amount. e.g., USD, INR alternative currencies, like bitcoin or points systems..</param>
        /// <param name="type">Type of the promotion e.g., First Time, Refer, Diwali.</param>
        public Promotion(string promotionId = default(string), string status = default(string), string description = default(string), string amount = default(string), string minPurchaseAmount = default(string), string referrerUserId = default(string), string failureReason = default(string), string percentageOff = default(string), string currencyCode = default(string), string type = default(string))
        {
            this.promotionId = promotionId;
            this.status = status;
            this.description = description;
            this.amount = amount;
            this.minPurchaseAmount = minPurchaseAmount;
            this.referrerUserId = referrerUserId;
            this.failureReason = failureReason;
            this.percentageOff = percentageOff;
            this.currencyCode = currencyCode;
            this.type = type;
        }
        
        /// <summary>
        /// The ID/Coupon Code within your system that you use to represent this promotion. This ID is ideally unique to the promotion across users (e.g. \&quot;Welcome\&quot;).
        /// </summary>
        /// <value>The ID/Coupon Code within your system that you use to represent this promotion. This ID is ideally unique to the promotion across users (e.g. \&quot;Welcome\&quot;).</value>
        [DataMember(Name="_promotionId", EmitDefaultValue=false)]
        public string promotionId { get; set; }

        /// <summary>
        /// The status of the addition of promotion to an account. Best used with the add_promotion event. This way you can pass to Thirdwatch both successful and failed attempts when using a promotion. May be useful in spotting potential abuse. e.g. _success, _Failed
        /// </summary>
        /// <value>The status of the addition of promotion to an account. Best used with the add_promotion event. This way you can pass to Thirdwatch both successful and failed attempts when using a promotion. May be useful in spotting potential abuse. e.g. _success, _Failed</value>
        [DataMember(Name="_status", EmitDefaultValue=false)]
        public string status { get; set; }

        /// <summary>
        /// Describe promotion here.
        /// </summary>
        /// <value>Describe promotion here.</value>
        [DataMember(Name="_description", EmitDefaultValue=false)]
        public string description { get; set; }

        /// <summary>
        /// The amount or credits the promotion is worth.
        /// </summary>
        /// <value>The amount or credits the promotion is worth.</value>
        [DataMember(Name="_amount", EmitDefaultValue=false)]
        public string amount { get; set; }

        /// <summary>
        /// The minimum amount someone must spend in order for the promotion to be applied.
        /// </summary>
        /// <value>The minimum amount someone must spend in order for the promotion to be applied.</value>
        [DataMember(Name="_minPurchaseAmount", EmitDefaultValue=false)]
        public string minPurchaseAmount { get; set; }

        /// <summary>
        /// The unique user ID of the user who referred the user to this promotion.
        /// </summary>
        /// <value>The unique user ID of the user who referred the user to this promotion.</value>
        [DataMember(Name="_referrerUserId", EmitDefaultValue=false)]
        public string referrerUserId { get; set; }

        /// <summary>
        /// When adding a promotion fails, use this to describe why it failed.e.g. _alreadyUsed, _invalidCode, _notApplicable, _expired
        /// </summary>
        /// <value>When adding a promotion fails, use this to describe why it failed.e.g. _alreadyUsed, _invalidCode, _notApplicable, _expired</value>
        [DataMember(Name="_failureReason", EmitDefaultValue=false)]
        public string failureReason { get; set; }

        /// <summary>
        /// The percentage discount. If the discount is 10% off, you would send \&quot;10\&quot;.
        /// </summary>
        /// <value>The percentage discount. If the discount is 10% off, you would send \&quot;10\&quot;.</value>
        [DataMember(Name="_percentageOff", EmitDefaultValue=false)]
        public string percentageOff { get; set; }

        /// <summary>
        /// The [ISO-4217](http://en.wikipedia.org/wiki/ISO_4217) currency code for the amount. e.g., USD, INR alternative currencies, like bitcoin or points systems.
        /// </summary>
        /// <value>The [ISO-4217](http://en.wikipedia.org/wiki/ISO_4217) currency code for the amount. e.g., USD, INR alternative currencies, like bitcoin or points systems.</value>
        [DataMember(Name="_currencyCode", EmitDefaultValue=false)]
        public string currencyCode { get; set; }

        /// <summary>
        /// Type of the promotion e.g., First Time, Refer, Diwali
        /// </summary>
        /// <value>Type of the promotion e.g., First Time, Refer, Diwali</value>
        [DataMember(Name="_type", EmitDefaultValue=false)]
        public string type { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Promotion {\n");
            sb.Append("  promotionId: ").Append(promotionId).Append("\n");
            sb.Append("  status: ").Append(status).Append("\n");
            sb.Append("  description: ").Append(description).Append("\n");
            sb.Append("  amount: ").Append(amount).Append("\n");
            sb.Append("  minPurchaseAmount: ").Append(minPurchaseAmount).Append("\n");
            sb.Append("  referrerUserId: ").Append(referrerUserId).Append("\n");
            sb.Append("  failureReason: ").Append(failureReason).Append("\n");
            sb.Append("  percentageOff: ").Append(percentageOff).Append("\n");
            sb.Append("  currencyCode: ").Append(currencyCode).Append("\n");
            sb.Append("  type: ").Append(type).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as Promotion);
        }

        /// <summary>
        /// Returns true if Promotion instances are equal
        /// </summary>
        /// <param name="input">Instance of Promotion to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Promotion input)
        {
            if (input == null)
                return false;

            return 
                (
                    this.promotionId == input.promotionId ||
                    (this.promotionId != null &&
                    this.promotionId.Equals(input.promotionId))
                ) && 
                (
                    this.status == input.status ||
                    (this.status != null &&
                    this.status.Equals(input.status))
                ) && 
                (
                    this.description == input.description ||
                    (this.description != null &&
                    this.description.Equals(input.description))
                ) && 
                (
                    this.amount == input.amount ||
                    (this.amount != null &&
                    this.amount.Equals(input.amount))
                ) && 
                (
                    this.minPurchaseAmount == input.minPurchaseAmount ||
                    (this.minPurchaseAmount != null &&
                    this.minPurchaseAmount.Equals(input.minPurchaseAmount))
                ) && 
                (
                    this.referrerUserId == input.referrerUserId ||
                    (this.referrerUserId != null &&
                    this.referrerUserId.Equals(input.referrerUserId))
                ) && 
                (
                    this.failureReason == input.failureReason ||
                    (this.failureReason != null &&
                    this.failureReason.Equals(input.failureReason))
                ) && 
                (
                    this.percentageOff == input.percentageOff ||
                    (this.percentageOff != null &&
                    this.percentageOff.Equals(input.percentageOff))
                ) && 
                (
                    this.currencyCode == input.currencyCode ||
                    (this.currencyCode != null &&
                    this.currencyCode.Equals(input.currencyCode))
                ) && 
                (
                    this.type == input.type ||
                    (this.type != null &&
                    this.type.Equals(input.type))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.promotionId != null)
                    hashCode = hashCode * 59 + this.promotionId.GetHashCode();
                if (this.status != null)
                    hashCode = hashCode * 59 + this.status.GetHashCode();
                if (this.description != null)
                    hashCode = hashCode * 59 + this.description.GetHashCode();
                if (this.amount != null)
                    hashCode = hashCode * 59 + this.amount.GetHashCode();
                if (this.minPurchaseAmount != null)
                    hashCode = hashCode * 59 + this.minPurchaseAmount.GetHashCode();
                if (this.referrerUserId != null)
                    hashCode = hashCode * 59 + this.referrerUserId.GetHashCode();
                if (this.failureReason != null)
                    hashCode = hashCode * 59 + this.failureReason.GetHashCode();
                if (this.percentageOff != null)
                    hashCode = hashCode * 59 + this.percentageOff.GetHashCode();
                if (this.currencyCode != null)
                    hashCode = hashCode * 59 + this.currencyCode.GetHashCode();
                if (this.type != null)
                    hashCode = hashCode * 59 + this.type.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}