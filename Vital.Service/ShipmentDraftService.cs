using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vital.Data.Models;

namespace Vital.Service
{
    public class ShipmentDraftService : IShipmentDraftService
    {
        private readonly IRepository<ShipmentDraft> _shipmentDraftRespository;
        readonly IUnitOfWork _unitOfWork;

        public ShipmentDraftService(
            IRepository<ShipmentDraft> _shipmentDraftRespository
            , IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
            this._shipmentDraftRespository = _shipmentDraftRespository;
        }

        public string SaveShipment(Model.ShipmentModel model, string userName)
        {
            Guid id = Guid.NewGuid();
            var data = ModelToData(model);

            data.DateModified = DateTime.Now;
            data.ShipmentDraftId = id;
            data.Status = "Draft";
            data.Username = userName;

            _shipmentDraftRespository.Insert(data);

            return id.ToString();
        }

        public void FinalizeShipmentDraft(string action, Guid id)
        {
            var data = _shipmentDraftRespository.Query().Filter(r => r.ShipmentDraftId == id).Get().First();

            data.Status = action;
            data.DateModified = DateTime.Now;

            _shipmentDraftRespository.Update(data);
        }

        public void UpdateShipmentDraft(Model.ShipmentModel model, Guid id)
        {
            var data = ModelToData(model, id);

            if (!model.IsSuccess)
            {
                data.Status = "Draft";
                data.DateModified = DateTime.Now;
            }

            _shipmentDraftRespository.Update(data);
        }

        public Model.ShipmentModel GetShipmentData(Guid id)
        {
            var data = _shipmentDraftRespository.Query().Filter(r => r.ShipmentDraftId == id).Get().First();
            return DataToModel(data);
        }

        public void CancelScheduledPickup(Guid id)
        {
            var data = _shipmentDraftRespository.Query().Filter(r => r.ShipmentDraftId == id).Get().First();

            data.IsScheduledPickup = false;

            _shipmentDraftRespository.Update(data);
        }

        public bool HasShipmentDraftData(string username)
        {
            return _shipmentDraftRespository.Query().Filter(r => r.Username == username && r.Status == "Draft").Get().Any();
        }

        public Model.ShipmentModel DataToModel(ShipmentDraft data)
        {
            Model.ShipmentModel model = new Model.ShipmentModel();

            model.DraftId = data.ShipmentDraftId.ToString();
            model.ShipperNumber = data.ShipperNumber;
            model.AccountNumber = data.AccountNumber;
            model.ConsigneeIsEditMode = data.ConsigneeIsEditMode;
            model.ConsigneeAddressBookId = data.ConsigneeAddressBookId;
            model.ConsigneeCompanyName = data.ConsigneeCompanyName;
            model.ConsigneeContactName = data.ConsigneeContactName;
            model.ConsigneeCountry = data.ConsigneeCountry;
            model.ConsigneeAddress1 = data.ConsigneeAddress1;
            model.ConsigneeAddress2 = data.ConsigneeAddress2;
            model.ConsigneeAddress3 = data.ConsigneeAddress3;
            model.ConsigneeCity = data.ConsigneeCity;
            model.ConsigneeProvince = data.ConsigneeProvince;
            model.ConsigneePostalCode = data.ConsigneePostalCode;
            model.ConsigneeTelephone = data.ConsigneeTelephone;
            model.ConsigneeTelephoneExt = data.ConsigneeTelephoneExt;
            model.ConsigneeEmail = data.ConsigneeEmail;
            model.ConsigneeIsResidential = data.ConsigneeIsResidential;
            model.ConsigneeSaveOptionForAddress = data.ConsigneeSaveOptionForAddress;
            model.ConsigneeSaveAddressBookAs = data.ConsigneeSaveAddressBookAs;
            model.ConsignorReturnAddressQuestion = data.ConsignorReturnAddressQuestion;
            model.ConsignorCompanyName = data.ConsignorCompanyName;
            model.ConsignorContactName = data.ConsignorContactName;
            model.ConsignorCountry = data.ConsignorCountry;
            model.ConsignorAddress1 = data.ConsignorAddress1;
            model.ConsignorAddress2 = data.ConsignorAddress2;
            model.ConsignorAddress3 = data.ConsignorAddress3;
            model.ConsignorCity = data.ConsignorCity;
            model.ConsignorProvince = data.ConsignorProvince;
            model.ConsignorPostalCode = data.ConsignorPostalCode;
            model.ConsignorTelephone = data.ConsignorTelephone;
            model.ConsignorTelephoneExt = data.ConsignorTelephoneExt;
            model.ConsignorEmail = data.ConsignorEmail;
            model.ConsignorIsResidential = data.ConsignorIsResidential;
            model.ConsignorSaveOptionForAddress = data.ConsignorSaveOptionForAddress;
            model.ConsignorSaveAddressBookAs = data.ConsignorSaveAddressBookAs;
            model.ConsignorSaveOptionForCorporateAddress = data.ConsignorSaveOptionForCorporateAddress;
            model.ConsignorSaveCorporateAddressBookAs = data.ConsignorSaveCorporateAddressBookAs;
            model.NoOfPackage = data.NoOfPackage;
            model.Weight = data.Weight;
            model.UnitOfMeasurement = data.UnitOfMeasurement;
            model.PackagingType = data.PackagingType;
            model.PackageDimensionsLength = data.PackageDimensionsLength;
            model.PackageDimensionsWidth = data.PackageDimensionsWidth;
            model.PackageDimensionsHeight = data.PackageDimensionsHeight;
            model.PackageDeclaredValueCAD = data.PackageDeclaredValueCAD;
            model.LargePackage = data.LargePackage;
            model.AdditionalHandling = data.AdditionalHandling;
            model.ServiceType = data.ServiceType;
            model.SendEmailNotification = data.SendEmailNotification;
            model.ReceiveConfirmationofDelivery = data.ReceiveConfirmationofDelivery;
            model.DeliverOnSaturday = data.DeliverOnSaturday;
            model.COD = data.COD;
            model.ReferenceNumber1 = data.ReferenceNumber1;
            model.ReferenceNumber2 = data.ReferenceNumber2;
            model.ReferenceNumber3 = data.ReferenceNumber3;
            model.AccountId = data.AccountId;
            model.IsScheduledPickup = data.IsScheduledPickup;
            model.collectionDate = data.collectionDate;
            model.latestPickupTimeHour = data.latestPickupTimeHour;
            model.latestPickupTimeMinute = data.latestPickupTimeMinute;
            model.earliestPickupTimeHour = data.earliestPickupTimeHour;
            model.earliestPickupTimeMinute = data.earliestPickupTimeMinute;
            model.ampm = data.ampm;
            model.contactName = data.contactName;
            model.telephone = data.telephone;
            model.extension = data.extension;
            model.room = data.room;
            model.floor = data.floor;
            model.pickupLocation = data.pickupLocation;
            model.IsResidential = data.IsResidential;
            model.pickupIdentificationNumber = data.pickupIdentificationNumber;
            model.IsForReview = data.IsForReview;

            return model;
        }

        public ShipmentDraft ModelToData(Model.ShipmentModel model)
        {
            ShipmentDraft Draft = new ShipmentDraft();

            Draft.ShipperNumber = model.ShipperNumber;
            Draft.AccountNumber = model.AccountNumber;
            Draft.Status = "Draft";
            Draft.DateModified = DateTime.Now;
            Draft.ConsigneeIsEditMode = model.ConsigneeIsEditMode;
            Draft.ConsigneeAddressBookId = model.ConsigneeAddressBookId;
            Draft.ConsigneeCompanyName = model.ConsigneeCompanyName;
            Draft.ConsigneeContactName = model.ConsigneeContactName;
            Draft.ConsigneeCountry = model.ConsigneeCountry;
            Draft.ConsigneeAddress1 = model.ConsigneeAddress1;
            Draft.ConsigneeAddress2 = model.ConsigneeAddress2;
            Draft.ConsigneeAddress3 = model.ConsigneeAddress3;
            Draft.ConsigneeCity = model.ConsigneeCity;
            Draft.ConsigneeProvince = model.ConsigneeProvince;
            Draft.ConsigneePostalCode = model.ConsigneePostalCode;
            Draft.ConsigneeTelephone = model.ConsigneeTelephone;
            Draft.ConsigneeTelephoneExt = model.ConsigneeTelephoneExt;
            Draft.ConsigneeEmail = model.ConsigneeEmail;
            Draft.ConsigneeIsResidential = model.ConsigneeIsResidential;
            Draft.ConsigneeSaveOptionForAddress = model.ConsigneeSaveOptionForAddress;
            Draft.ConsigneeSaveAddressBookAs = model.ConsigneeSaveAddressBookAs;
            Draft.ConsignorReturnAddressQuestion = model.ConsignorReturnAddressQuestion;
            Draft.ConsignorCompanyName = model.ConsignorCompanyName;
            Draft.ConsignorContactName = model.ConsignorContactName;
            Draft.ConsignorCountry = model.ConsignorCountry;
            Draft.ConsignorAddress1 = model.ConsignorAddress1;
            Draft.ConsignorAddress2 = model.ConsignorAddress2;
            Draft.ConsignorAddress3 = model.ConsignorAddress3;
            Draft.ConsignorCity = model.ConsignorCity;
            Draft.ConsignorProvince = model.ConsignorProvince;
            Draft.ConsignorPostalCode = model.ConsignorPostalCode;
            Draft.ConsignorTelephone = model.ConsignorTelephone;
            Draft.ConsignorTelephoneExt = model.ConsignorTelephoneExt;
            Draft.ConsignorEmail = model.ConsignorEmail;
            Draft.ConsignorIsResidential = model.ConsignorIsResidential;
            Draft.ConsignorSaveOptionForAddress = model.ConsignorSaveOptionForAddress;
            Draft.ConsignorSaveAddressBookAs = model.ConsignorSaveAddressBookAs;
            Draft.ConsignorSaveOptionForCorporateAddress = model.ConsignorSaveOptionForCorporateAddress;
            Draft.ConsignorSaveCorporateAddressBookAs = model.ConsignorSaveCorporateAddressBookAs;
            Draft.NoOfPackage = model.NoOfPackage;
            Draft.Weight = model.Weight;
            Draft.UnitOfMeasurement = model.UnitOfMeasurement;
            Draft.PackagingType = model.PackagingType;
            Draft.PackageDimensionsLength = model.PackageDimensionsLength;
            Draft.PackageDimensionsWidth = model.PackageDimensionsWidth;
            Draft.PackageDimensionsHeight = model.PackageDimensionsHeight;
            Draft.PackageDeclaredValueCAD = model.PackageDeclaredValueCAD;
            Draft.LargePackage = model.LargePackage;
            Draft.AdditionalHandling = model.AdditionalHandling;
            Draft.ServiceType = model.ServiceType;
            Draft.SendEmailNotification = model.SendEmailNotification;
            Draft.ReceiveConfirmationofDelivery = model.ReceiveConfirmationofDelivery;
            Draft.DeliverOnSaturday = model.DeliverOnSaturday;
            Draft.COD = model.COD;
            Draft.ReferenceNumber1 = model.ReferenceNumber1;
            Draft.ReferenceNumber2 = model.ReferenceNumber2;
            Draft.ReferenceNumber3 = model.ReferenceNumber3;
            Draft.AccountId = model.AccountId;
            Draft.IsScheduledPickup = model.IsScheduledPickup;
            Draft.collectionDate = model.collectionDate;
            Draft.latestPickupTimeHour = model.latestPickupTimeHour;
            Draft.latestPickupTimeMinute = model.latestPickupTimeMinute;
            Draft.earliestPickupTimeHour = model.earliestPickupTimeHour;
            Draft.earliestPickupTimeMinute = model.earliestPickupTimeMinute;
            Draft.ampm = model.ampm;
            Draft.contactName = model.contactName;
            Draft.telephone = model.telephone;
            Draft.extension = model.extension;
            Draft.room = model.room;
            Draft.floor = model.floor;
            Draft.pickupLocation = model.pickupLocation;
            Draft.IsResidential = model.IsResidential;
            Draft.pickupIdentificationNumber = model.pickupIdentificationNumber;
            Draft.IsForReview = model.IsForReview;
            Draft.UPS_Username = model.UPS_Username;
            Draft.UPS_Password = model.UPS_Password;

            return Draft;
        }

        public ShipmentDraft ModelToData(Model.ShipmentModel model, Guid id)
        {
            ShipmentDraft Draft = _shipmentDraftRespository.Query().Filter(r => r.ShipmentDraftId == id).Get().First();

            Draft.ShipperNumber = model.ShipperNumber;
            Draft.AccountNumber = model.AccountNumber;
            Draft.Status = "Draft";
            Draft.DateModified = DateTime.Now;
            Draft.ConsigneeIsEditMode = model.ConsigneeIsEditMode;
            Draft.ConsigneeAddressBookId = model.ConsigneeAddressBookId;
            Draft.ConsigneeCompanyName = model.ConsigneeCompanyName;
            Draft.ConsigneeContactName = model.ConsigneeContactName;
            Draft.ConsigneeCountry = model.ConsigneeCountry;
            Draft.ConsigneeAddress1 = model.ConsigneeAddress1;
            Draft.ConsigneeAddress2 = model.ConsigneeAddress2;
            Draft.ConsigneeAddress3 = model.ConsigneeAddress3;
            Draft.ConsigneeCity = model.ConsigneeCity;
            Draft.ConsigneeProvince = model.ConsigneeProvince;
            Draft.ConsigneePostalCode = model.ConsigneePostalCode;
            Draft.ConsigneeTelephone = model.ConsigneeTelephone;
            Draft.ConsigneeTelephoneExt = model.ConsigneeTelephoneExt;
            Draft.ConsigneeEmail = model.ConsigneeEmail;
            Draft.ConsigneeIsResidential = model.ConsigneeIsResidential;
            Draft.ConsigneeSaveOptionForAddress = model.ConsigneeSaveOptionForAddress;
            Draft.ConsigneeSaveAddressBookAs = model.ConsigneeSaveAddressBookAs;
            Draft.ConsignorReturnAddressQuestion = model.ConsignorReturnAddressQuestion;
            Draft.ConsignorCompanyName = model.ConsignorCompanyName;
            Draft.ConsignorContactName = model.ConsignorContactName;
            Draft.ConsignorCountry = model.ConsignorCountry;
            Draft.ConsignorAddress1 = model.ConsignorAddress1;
            Draft.ConsignorAddress2 = model.ConsignorAddress2;
            Draft.ConsignorAddress3 = model.ConsignorAddress3;
            Draft.ConsignorCity = model.ConsignorCity;
            Draft.ConsignorProvince = model.ConsignorProvince;
            Draft.ConsignorPostalCode = model.ConsignorPostalCode;
            Draft.ConsignorTelephone = model.ConsignorTelephone;
            Draft.ConsignorTelephoneExt = model.ConsignorTelephoneExt;
            Draft.ConsignorEmail = model.ConsignorEmail;
            Draft.ConsignorIsResidential = model.ConsignorIsResidential;
            Draft.ConsignorSaveOptionForAddress = model.ConsignorSaveOptionForAddress;
            Draft.ConsignorSaveAddressBookAs = model.ConsignorSaveAddressBookAs;
            Draft.ConsignorSaveOptionForCorporateAddress = model.ConsignorSaveOptionForCorporateAddress;
            Draft.ConsignorSaveCorporateAddressBookAs = model.ConsignorSaveCorporateAddressBookAs;
            Draft.NoOfPackage = model.NoOfPackage;
            Draft.Weight = model.Weight;
            Draft.UnitOfMeasurement = model.UnitOfMeasurement;
            Draft.PackagingType = model.PackagingType;
            Draft.PackageDimensionsLength = model.PackageDimensionsLength;
            Draft.PackageDimensionsWidth = model.PackageDimensionsWidth;
            Draft.PackageDimensionsHeight = model.PackageDimensionsHeight;
            Draft.PackageDeclaredValueCAD = model.PackageDeclaredValueCAD;
            Draft.LargePackage = model.LargePackage;
            Draft.AdditionalHandling = model.AdditionalHandling;
            Draft.ServiceType = model.ServiceType;
            Draft.SendEmailNotification = model.SendEmailNotification;
            Draft.ReceiveConfirmationofDelivery = model.ReceiveConfirmationofDelivery;
            Draft.DeliverOnSaturday = model.DeliverOnSaturday;
            Draft.COD = model.COD;
            Draft.ReferenceNumber1 = model.ReferenceNumber1;
            Draft.ReferenceNumber2 = model.ReferenceNumber2;
            Draft.ReferenceNumber3 = model.ReferenceNumber3;
            Draft.AccountId = model.AccountId;
            Draft.IsScheduledPickup = model.IsScheduledPickup;
            Draft.collectionDate = model.collectionDate;
            Draft.latestPickupTimeHour = model.latestPickupTimeHour;
            Draft.latestPickupTimeMinute = model.latestPickupTimeMinute;
            Draft.earliestPickupTimeHour = model.earliestPickupTimeHour;
            Draft.earliestPickupTimeMinute = model.earliestPickupTimeMinute;
            Draft.ampm = model.ampm;
            Draft.contactName = model.contactName;
            Draft.telephone = model.telephone;
            Draft.extension = model.extension;
            Draft.room = model.room;
            Draft.floor = model.floor;
            Draft.pickupLocation = model.pickupLocation;
            Draft.IsResidential = model.IsResidential;
            Draft.pickupIdentificationNumber = model.pickupIdentificationNumber;
            Draft.IsForReview = model.IsForReview;

            return Draft;
        }
    }
}
