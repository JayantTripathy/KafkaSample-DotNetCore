# KafkaSample-DotNetCore

This repository demonstrates a simple Apache Kafka integration using .NET Core, consisting of a Producer API and a Consumer console application.

## 🔧 Project Structure

- **KafkaSample.ProducerAPI** – ASP.NET Core Web API that produces messages to Kafka.
- **KafkaSample.Consumer** – Console application that consumes messages from Kafka.
- **docker-compose.yml** – Docker setup to run Kafka and Zookeeper locally.

## Demo
<img src="https://github.com/JayantTripathy/KafkaSample-DotNetCore/blob/master/Kafka-dotnetcore.gif"/>

## 🛠 Prerequisites

- [.NET 6 SDK or later](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)

## 🚀 Getting Started

### Step 1: Start Kafka Locally

Use Docker Compose to start Kafka and Zookeeper:

```bash
docker compose up -d
```

This will start:
- Kafka on `localhost:9092`
- Zookeeper on `localhost:2181`

### Step 2: Run the Producer API

```bash
cd KafkaSample.ProducerAPI
dotnet restore
dotnet run
```

API will run at: `http://localhost:5000`

### Step 3: Run the Consumer

```bash
cd KafkaSample.Consumer
dotnet restore
dotnet run
```

This will start listening to the Kafka topic and print incoming messages.

### Step 4: Produce a Message

Use a tool like Postman or curl:

```bash
curl -X POST http://localhost:5000/api/produce \
     -H "Content-Type: application/json" \
     -d '{"key":"sample-key", "value":"Hello Kafka!"}'
```

You should see this message consumed in the Consumer console output.

## 🧪 Run Unit Tests (If Included)

```bash
cd KafkaSample.UnitTest
dotnet test
```

## 🧰 Troubleshooting

- **Docker not recognized?** Use `docker compose` instead of `docker-compose`.
- **Ports in use?** Change Kafka or API port in the Docker file or appsettings.
- **Kafka errors?** Ensure Zookeeper and Kafka are up and running via `docker ps`.

## 📚 Resources

- [Confluent Kafka .NET Client](https://github.com/confluentinc/confluent-kafka-dotnet)
- [Apache Kafka Docs](https://kafka.apache.org/documentation/)

---

✅ Built for educational purposes. Adapt as needed for production usage.

---

Made with ❤️ by [JayantTripathy](https://github.com/JayantTripathy)

