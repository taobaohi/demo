## create table
```sql
CREATE TABLE `user` (
  `name` varchar(16) NOT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `userid` bigint(20) NOT NULL,
  `create_time` timestamp NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
```

## 连接池
[connection-pooling](https://dev.mysql.com/doc/connector-j/8.0/en/connector-j-usagenotes-j2ee-concepts-connection-pooling.html)

## package
https://mvnrepository.com/