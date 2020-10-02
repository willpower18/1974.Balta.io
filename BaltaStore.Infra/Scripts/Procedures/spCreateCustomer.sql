CREATE DEFINER=`root`@`localhost` PROCEDURE `spCreateCustomer`(
	in id varchar(36),
	in firstName varchar(40),
	in lastName VARCHAR(40),
	in document VARCHAR(11),
	in email VARCHAR(160),
	in phone VARCHAR(13)
)
BEGIN
	INSERT INTO address (Id, FirstName, LastName, Document, Email, Phone)
    VALUES (Id, firstName, lastName, document, email, phone);
END