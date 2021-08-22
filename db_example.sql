/**
CREATE SCHEMA parking_lot;
**/
USE parking_lot

CREATE TABLE parking_lot
(
    id int IDENTITY (1,1) NOT NULL,
    name VARCHAR(15) not null,
	CONSTRAINT PK_parking_lot_id PRIMARY KEY CLUSTERED (id)
);

INSERT INTO parking_lot(name)
VALUES('A'), ('B'), ('C');



CREATE TABLE vehicle
(
    id int IDENTITY (1,1) NOT NULL,
    make VARCHAR(50) not null,
    model VARCHAR(50) not null,
    type VARCHAR(50) not null,
	CONSTRAINT PK_vehicle_id PRIMARY KEY CLUSTERED (id)
);

INSERT INTO vehicle(make, model, type)
VALUES('VW', 'Golf', 'Car'), ('BMW', 'Touring', 'motorcycle'), ('Volkswagen', 'Jetta', 'Car'), ('Ford', 'Club Wagon', 'Van');



CREATE TABLE parking_lot_space_type
(
    id int IDENTITY (1,1) NOT NULL,
    name VARCHAR(50) not null,
	weight int default 1,
	CONSTRAINT PK_parking_lot_space_type_id PRIMARY KEY CLUSTERED (id)
);

INSERT INTO parking_lot_space_type(name,weight)
VALUES('Motorcycle',1), ('Car',2), ('Large',3);

CREATE TABLE parking_space
(
    id int IDENTITY (1,1) NOT NULL,
    lot int,
	space_type int,
    right_space int,
	Left_space int,
    is_full int DEFAULT 0,		
	vehicle int,
	CONSTRAINT PK_parking_space_id PRIMARY KEY CLUSTERED (id)
);

INSERT INTO [dbo].[parking_space]
           ([lot]
           ,[space_type]
           ,[right_space]
           ,[Left_space],
		   [is_full],
		    [vehicle]
           )
VALUES(1,1,NULL,2,1,1),
(1,1,1,3,1,1),(1,1,2,4,1,1),(1,1,3,5,0,NULL),(1,1,4,6,0,NULL),(1,2,5,7,1,2),(1,2,6,8,0,NULL),(1,2,7,9,1,2),(1,2,8,10,0,NULL),(1,2,9,NULL,1,2),(1,2,NULL,12,0,NULL),
(1,3,11,13,1,2),(1,3,12,14,0,NULL),(1,3,13,15,1,3),(1,3,14,16,1,3),(1,3,15,17,1,3),(1,3,16,18,1,2),(1,3,17,19,1,3),(1,3,18,20,1,3),(1,3,19,NULL,1,3),(2,1,NULL,2,1,1),
(2,1,1,3,0,NULL),(2,1,2,4,0,NULL),(2,1,3,5,0,NULL),(2,1,4,6,0,NULL),(2,2,5,7,1,2),(2,2,6,8,0,NULL),(2,2,7,9,1,2),(2,2,8,10,0,NULL),(2,2,9,NULL,1,2),(2,2,NULL,12,0,NULL),
(2,3,11,13,1,2),(2,3,12,14,0,NULL),(2,3,13,15,1,NULL),(2,3,14,16,1,3),(2,3,15,17,1,3),(2,3,16,18,1,3),(2,3,17,19,1,NULL),(2,3,18,20,1,NULL),(2,3,19,NULL,1,NULL),(3,1,NULL,2,1,1),
(3,1,1,3,0,NULL),(3,1,2,4,0,NULL),(3,1,3,5,0,NULL),(3,1,4,6,0,NULL),(3,2,5,7,1,2),(3,2,6,8,0,NULL),(3,2,7,9,1,2),(3,2,8,10,0,NULL),(3,2,9,NULL,1,2),(3,2,NULL,12,0,NULL),
(3,3,11,13,1,2),(3,3,12,14,0,3),(3,3,13,15,1,3),(3,3,14,16,1,3),(3,3,15,17,1,NULL),(3,3,16,18,1,3),(3,3,17,19,1,3),(3,3,18,20,1,3)
(3,3,19,NULL,1,NULL);

 /**
  Overview by vehicle type
  **/
  CREATE PROCEDURE [dbo].[overview_by_vehicle]
AS  
SET NOCOUNT ON; 
    SELECT pl.name as LotName,
	SUM(CASE WHEN ps.vehicle=1 THEN 1 ELSE 0 END) AS MotorCycle,
	SUM(CASE WHEN ps.vehicle=2 THEN 1 ELSE 0 END) AS Car,
	(SUM(CASE WHEN ps.vehicle=3 THEN 1 ELSE 0 END))/3 AS Van
  FROM parking_lot.dbo.parking_space AS ps
  LEFT JOIN parking_lot AS pl ON pl.id=ps.lot
  LEFT JOIN parking_lot_space_type AS plpt ON plpt.id = ps.space_type
  LEFT JOIN vehicle AS v ON V.id=ps.vehicle
 GROUP BY pl.name
GO

CREATE PROCEDURE [dbo].[space_overview] 
AS  
  SET NOCOUNT ON;  
  SELECT pl.name as LotName,plpt.name as SpaceType,COUNT(plpt.name) AS Total,
  SUM(is_full) AS Taken,  
  SUM(  CASE  WHEN is_full=0  THEN 1 ELSE 0 END) AS 'Open'
  FROM parking_lot.dbo.parking_space AS ps
  LEFT JOIN parking_lot AS pl ON pl.id=ps.lot
  LEFT JOIN parking_lot_space_type AS plpt ON plpt.id = ps.space_type
 GROUP BY pl.name,plpt.name
GO




