# 🚀 **FastProjects.Messaging**

![Build Status](https://github.com/Fast-Projects-NET/FastProjects.Messaging/actions/workflows/test.yml/badge.svg)
![NuGet](https://img.shields.io/nuget/v/FastProjects.Messaging.svg)
![NuGet Downloads](https://img.shields.io/nuget/dt/FastProjects.Messaging.svg)
![License](https://img.shields.io/github/license/Fast-Projects-NET/FastProjects.Messaging.svg)
![Last Commit](https://img.shields.io/github/last-commit/Fast-Projects-NET/FastProjects.Messaging.svg)
![GitHub Stars](https://img.shields.io/github/stars/Fast-Projects-NET/FastProjects.Messaging.svg)
![GitHub Forks](https://img.shields.io/github/forks/Fast-Projects-NET/FastProjects.Messaging.svg)

> 🚨 ALERT: Project Under Development
> This project is not yet production-ready and is still under active development. Currently, it's being used primarily for personal development needs. However, contributions are more than welcome! If you'd like to collaborate, feel free to submit issues or pull requests. Your input can help shape the future of FastProjects!

---

## 📚 **Overview**

Collection of interfaces to work with integration events and messaging systems integrated with MassTransit.

---

## 🛠 **Roadmap**

- ✅ [IIntegrationEvent](src/FastProjects.Messaging/IIntegrationEvent.cs) - Interface for integration events
- ✅ [IIntegrationEventConsumer](src/FastProjects.Messaging/IIntegrationEventConsumer.cs) - Interface for integration event consumers
- ✅ [IIntegrationEventPublisher](src/FastProjects.Messaging/IIntegrationEventPublisher.cs) - Interface for integration event publishers
- ✅ [MassTransitMessagePublisher](src/FastProjects.Messaging/MassTransitMessagePublisher.cs) - Implementation of `IIntegrationEventPublisher` that uses MassTransit
---

## 🚀 **Installation**

You can download the NuGet package using the following command to install:
```bash
dotnet add package FastProjects.Messaging
```

---

## 🤝 **Contributing**

This project is still under development, but contributions are welcome! Whether you’re opening issues, submitting pull requests, or suggesting new features, we appreciate your involvement. For more details, please check the [contribution guide](CONTRIBUTING.md). Let’s build something amazing together! 🎉

---

## 📄 **License**

FastProjects is licensed under the **MIT License**. See the [LICENSE](LICENSE) file for full details.
