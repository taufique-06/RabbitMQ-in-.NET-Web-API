# RabbitMQ-in-.NET-Web-API

# What is RabbitMQ?
It is a message broker which accepts and forwards messages. It works like a Postoffice. So we hand them a letter and the post office is going to be responsible for it to acctually deliver it to the right address. 

# How RabbitMQ works?
![rabbitmq](https://user-images.githubusercontent.com/85470428/215330425-9ef204cc-9b81-4977-8678-45a50beff589.png)

Whoever sending the messages is Publisher. So if we try to use our Application called 'A' to send the message, then the Application 'A' is the **Publisher**. On the other hand, if the Application 'B' receives this messages from A, then the Application 'B' is the **Consumer**. When the message is sent from **Publisher**, it basically arrived to a queue. The Red boxes are **Queue** in our case. Also the orders matter. If the message 1 comes first, then the message 1 has to deliver first. 

# Publish/Subscribe
![pub](https://user-images.githubusercontent.com/85470428/215331061-0b2b1c13-62f5-47ce-ad45-10a20188eadd.png)

For example: if we have two consumers and one consumer only interested in getting emails and other one only interested in getting messages regarding orders. Although as a publisher, it will send the both messages but the consumers will only listen which they are interested in. It can be done by subscribing. 

# Routing
![route](https://user-images.githubusercontent.com/85470428/215331753-c44042c1-90f2-487d-b9b0-3f524cabe5a0.png)

Routing means we are only sending messages to the queues selectively. As can be seen in the image that, we are sending differnt sort of messages such as 'Error', 'Info',
'Warning'. We can see in the image, one consumer is accepting everything but the other is selective, it is only receiving messages which has 'Error' type. 
