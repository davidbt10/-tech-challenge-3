# -tech-challenge-3

O Tech Challenge desta fase é o desenvolvimento de microsserviços, que comunicam entre si.
Foram desenvolvidos dois projetos:
- EasyMoneyBroker: projeto responsável por expor as APIs do produto
- EasyMoneyBackgroundWorker: projeto responsável por conter os jobs que serão executados em segundo plano

          Passo a Passo:

          1 - Será necessário subir um container do RabbitMQ
            docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq

          2 - Após isso, apenas executar os projetos EasyMoneyBroker e EasyMoneyBackgroundWorker


  Ob.: O banco de dados está configurado na minha conta da Azure, não é necessário subir local.
  Caso queira acessar, a connectionstring está no projeto.
