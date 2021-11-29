using ASCOPC.Domain.Contracts;
using ASCOPC.Domain.Entities;
using ASCOPC.Shared;
using ASCOPC.Shared.DTO;
using ASOPC.Application.Interfaces.Provider;
using ASOPC.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCOPC.Infrastructure.Provider
{
    public class FillComponentProvider// : IFillComponentProvider<Component>
    {
        private readonly IParserService _parser;
        private readonly IComponentService _component;
        public FillComponentProvider(IParserService parser, IComponentService component)
        {
            _parser = parser;
            _component = component;
        }

        //public async Task<IResult<Component>> FillComponent(string url)
        //{
            //var resultBuilder = OperationResult<ComponentsDTO>.CreateBuilder();

            //ComponentsDTO response = null;
            //try
            //{
            //    var item = await _parser.ParseItem(url);

            //    if (item == null)
            //        return resultBuilder.AppendError($"{item} is null")
            //            .BuildResult();

            //    var result = await _component.Add();
            //    if (!result.Successed)
            //        return resultBuilder.AppendError($"{result} is null")
            //            .BuildResult();

            //}
            //catch (Exception ex)
            //{
            //    return resultBuilder.AppendError(ex.Message)
            //        .BuildResult();
            //}

            //return resultBuilder.SetValue(response)
            //    .BuildResult();
        //}
    }
}
