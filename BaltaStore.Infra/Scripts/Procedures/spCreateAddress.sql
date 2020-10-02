CREATE DEFINER=`root`@`localhost` PROCEDURE `spCreateAddress`(
	in id varchar(36),
	in customerId varchar(36),
	in `number` VARCHAR(10),
	in complement VARCHAR(40),
	in district VARCHAR(60),
	in city VARCHAR(60),
	in state CHAR(2),
	in country CHAR(2),
	in zipCode CHAR(8),
	in `type` INT
)
BEGIN
	INSERT INTO address (Id, CustomerId, `Number`, Complement, District, City, State, Country, ZipCode, `Type`)
    VALUES (id, customerId, `number`, complement, district, city, state, country, zipCode, `type`);
END