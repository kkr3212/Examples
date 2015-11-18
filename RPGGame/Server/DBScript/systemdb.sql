create database if not exists rpggame_systemdb /*default character set utf8*/;
use rpggame_systemdb;





drop table if exists t_listdb;
create table t_listdb
(
    uid int primary key,
    worldid int not null,
    dbtype int not null,
    dbname varchar(45) not null,
    ipaddress varchar(20) not null,
    portno int not null,
    userid varchar(45) not null,
    passwd varchar(45) not null,
    charset varchar(45),
    shardkey_start int,
    shardkey_end int
) engine=innodb;





drop table if exists t_listserver;
create table t_listserver
(
    uid int primary key,
    worldid int not null,
    servertype int not null,
    servername varchar(45) not null,
    system_ipaddress varchar(20) not null,
    listen_ipaddress varchar(20) not null,
    listen_portno int not null
) engine=innodb;





drop table if exists t_listworld;
create table t_listworld
(
    worldid int primary key,
    worldname varchar(64) not null,
    isopen smallint not null
) engine=innodb;





insert into t_listdb values(1000, 0, 1, 'rpggame_systemdb', '127.0.0.1', 3306, 'root', '1111', null, null, null);
insert into t_listdb values(2000, 0, 2, 'rpggame_authdb', '127.0.0.1', 3306, 'root', '1111', null, null, null);
insert into t_listdb values(3001, 1, 3, 'rpggame_gamedb_0', '127.0.0.1', 3306, 'root', '1111', 'euckr', 1, 100);

insert into t_listserver values(10100, 0, 1, 'RPGGame_AuthServer', '127.0.0.1', '127.0.0.1', 10100);
insert into t_listserver values(10301, 1, 3, 'RPGGame_GameServer_0', '127.0.0.1', '127.0.0.1', 10301);

insert into t_listworld values(1, 'World 1', 1);
