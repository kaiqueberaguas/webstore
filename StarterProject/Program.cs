using Docker.DotNet;
using Docker.DotNet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarterProject
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando aplicação");

            //DockerClient client = new DockerClientConfiguration().CreateClient();//conectar ao daemon do docker

            //IList<ContainerListResponse> containers = await client.Containers.ListContainersAsync(new ContainersListParameters()
            //{
            //    Limit = 10
            //});
            //var config = new Config
            //var containerCreate = new CreateContainerParameters()
            //{

            //    Image = "Redis"
            //};
            //var container = await client.Containers.CreateContainerAsync(containerCreate);

            //await client.Images.CreateImageAsync(new ImagesCreateParameters()
            //{
            //    FromImage = "ravendb/ravendb",
            //    Tag = "5.1.2-ubuntu.20.04-x64"
            //},
            //    new AuthConfig()
            //    {
            //        Email = "ksakX@outlook.com",
            //        Username = "kaiquekb",
            //        Password = "3549azdu"
            //    },
            //    new Progress<JSONMessage>(c => Console.WriteLine(c.ProgressMessage))
            //);

            //Console.WriteLine("Hora de continuar");
            //Console.ReadKey();
            //var portas = new Dictionary<string, EmptyStruct>();
            //portas.Add("8080/tcp",
            //                new PortBinding[]
            //                {
            //                    new PortBinding()
            //                    {
            //                        HostPort = "8080"
            //                    }
            //                });
            //var containerCreate = new CreateContainerParameters()
            //{
            //    Image = @"ravendb/ravendb:5.1.2-ubuntu.20.04-x64",
            //    HostConfig = new HostConfig
            //    {
            //        PortBindings = new Dictionary<string, IList<PortBinding>>
            //        {
            //            {
            //                "8080/http",
            //                new PortBinding[]
            //                {
            //                    new PortBinding
            //                    {
            //                        HostPort = "8080"
            //                    }
            //                }
            //            }
            //        }
            //    },
            //    Name = "ravenDb"
            //};
            //var container = await client.Containers.CreateContainerAsync(containerCreate);

            //await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());

            //Console.WriteLine("Hora de continuar");
            //Console.ReadKey();
            //Console.WriteLine(containers.Count);
            Console.WriteLine("Aplicação encerrada");
        }
    }
}
