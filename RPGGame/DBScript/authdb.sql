create database if not exists rpggame_authdb /*default character set utf8*/;
use rpggame_authdb;





drop table if exists t_accounts;
create table t_accounts
(
    userno int primary key auto_increment,
    usertoken varchar(128) not null,
    userid varchar(64) null,
    passwd varchar(64) null,
    authkey int not null
) engine=innodb;

