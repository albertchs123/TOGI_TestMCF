create database db_mcf

use db_mcf

CREATE TABLE ms_storage_location (
    location_id VARCHAR(10) PRIMARY KEY not null,
    location_name VARCHAR(100)
);

CREATE TABLE ms_user (
    user_id BIGINT PRIMARY KEY not null,
    user_name VARCHAR(20),
    password VARCHAR(50),
    is_active BIT
);

CREATE TABLE tr_bpkb (
    agreement_number VARCHAR(100) PRIMARY KEY not null,
    bpkb_no VARCHAR(100),
    branch_id VARCHAR(10),
    bpkb_date DATETIME,
    faktur_no VARCHAR(100),
    faktur_date DATETIME,
    location_id VARCHAR(10),
    police_no VARCHAR(20),
    bpkb_date_in DATETIME,
    created_by VARCHAR(20) ,
    created_on DATETIME ,
    last_updated_by VARCHAR(20) ,
    last_updated_on DATETIME ,
);


insert into ms_storage_location (location_id,location_name) values ('1','Surabaya');
insert into ms_storage_location (location_id,location_name) values ('2','Jakarta');


select * from ms_user
select * from ms_storage_location
select * from tr_bpkb