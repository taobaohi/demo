# swagger annotation
pom.xml增加swagger依赖
```xml
<dependencies>
    <!-- swagger -->
    <dependency>
        <groupId>io.springfox</groupId>
        <artifactId>springfox-swagger2</artifactId>
        <version>2.5.0</version>
    </dependency>
    <!-- swagger-ui -->
    <dependency>
        <groupId>io.springfox</groupId>
        <artifactId>springfox-swagger-ui</artifactId>
        <version>2.5.0</version>
    </dependency>
</dependencies>    
```
## model annotation
import io.swagger.annotations.ApiModel;
- @ApiModel:对实体类做注释
- @ApiModelProperty:对实体类属性做注释

## interface annotation
import io.swagger.annotations.ApiModelProperty;
- @Api：对controller注释。
- @ApiOperation：对action注释。
- @ApiImplicitParams：参数注解的集合声明。
- @ApiImplicitParam：在@ApiImplicitParams注解中，说明一个请求参数的各个方面，该注解包含的常用选项有：
  - paramType：参数所放置的地方，包含query、header、path、body以及form，最常用的是前四个。
  - name：参数名；
  - dataType：参数类型，可以是基础数据类型，也可以是一个class；
  - required：参数是否必须传；
  - value：参数的注释，说明参数的意义；
  - defaultValue：参数的默认值
- @ApiResponses：包含接口的一组响应注解。
- @ApiResponse：用在@ApiResponses中，一般用于表达一个错误的响应信息。
  - code：即httpCode，例如400。
  - message：信息，例如"缺少请求参数"
  
## notice
- 对于@ApiImplicitParam的paramType：query、form域中的值需要使用@RequestParam获取。
- header域中的值需要使用@RequestHeader来获取，path域中的值需要使用@PathVariable来获取
- body域中的值使用@RequestBody来获取，否则可能出错；而且如果paramType是body，name就不能是body。
