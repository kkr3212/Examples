create database if not exists rpggame_gamedb_0 /*default character set utf8*/;
use rpggame_gamedb_0;





drop table if exists t_userinfo;
create table t_userinfo
(
    userno int primary key,
    nickname varchar(45) not null,
    level smallint not null,
    exp int not null,
    vip_level smallint not null,
    vip_exp int not null,
    main_characterno int not null,
    last_managermailno int not null
) engine=innodb;





drop table if exists t_userinfo_energy;
create table t_userinfo_energy
(
    userno int not null,
    energyid smallint not null,
    point int not null,
    last_updatetime datetime not null,
    
    primary key(userno, energyid)
) engine=innodb;
alter table t_userinfo_energy add index idx_userno(userno);





drop table if exists t_userinfo_resource;
create table t_userinfo_resource
(
    userno int not null,
    resourceid smallint not null,
    point int not null,
    
    primary key(userno, resourceid)
) engine=innodb;
alter table t_userinfo_resource add index idx_userno(userno);





drop table if exists t_inventory_character;
create table t_inventory_character
(
    characterno int primary key,
    userno int not null,
    characterid int not null,
    level smallint not null,
    exp int not null,
    gradeid smallint not null,
    promotionid smallint not null
) engine=innodb;
alter table t_inventory_character add index idx_userno(userno);





drop table if exists t_inventory_item;
create table t_inventory_item
(
    itemno int primary key,
    userno int not null,
    itemid int not null,
    promotionid smallint not null,
    quantity smallint not null
) engine=innodb;
alter table t_inventory_item add index idx_userno(userno);





drop table if exists t_playdeck;
create table t_playdeck
(
    userno int not null,
    decktype smallint not null,
    slotno smallint not null,
    
    characterno int not null,

    primary key(userno, decktype, slotno)
) engine=innodb;
alter table t_deck add index idx_userno(userno);





drop table if exists t_mailbox;
create table t_mailbox
(
    mailno bigint primary key auto_increment,
    manager_mailno int,
    userno int not null,
    sender_userno int not null,
    message varchar(512),
    reward_type smallint,
    reward_referenceid int,
    reward_amount smallint,
    isread smallint not null,
    expire_date datetime not null
) engine=innodb;





drop table if exists t_mailbox_manager;
create table t_mailbox_manager
(
    mailno int primary key auto_increment,
    userno_start int not null,
    userno_end int not null,
    message varchar(512),
    present_type smallint,
    present_reference int,
    present_amount smallint,
    expire_date datetime not null
) engine=innodb;





drop table if exists t_playstatus;
create table t_playstatus
(
    userno int not null,
    nodeid int not null,
    enter_count smallint not null,
    clear_count smallint not null,
    reward_count smallint not null,
    reward_status smallint not null,
    daily_enter_count smallint not null,
    daily_clear_count smallint not null,
    daily_refresh_count smallint not null,
    stepno smallint not null,
    last_updatetime datetime not null,

    primary key(userno, nodeid)
) engine=innodb;
alter table t_playstatus add index idx_userno(userno);
