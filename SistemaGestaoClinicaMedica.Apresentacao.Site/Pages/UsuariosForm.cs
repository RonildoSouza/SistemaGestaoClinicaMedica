using AutoMapper;
using Blazored.LocalStorage;
using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using SistemaGestaoClinicaMedica.Aplicacao.DTO;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Constantes;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Extensions;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Modelo;
using SistemaGestaoClinicaMedica.Apresentacao.Site.Servicos;
using SistemaGestaoClinicaMedica.Apresentacao.Site.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace SistemaGestaoClinicaMedica.Apresentacao.Site.Pages
{
    public partial class UsuariosForm
    {
        [Parameter] public Guid Id { get; set; }

        [Inject] private IMapper Mapper { get; set; }
        [Inject] private IJSRuntime JSRuntime { get; set; }
        [Inject] private ILocalStorageService LocalStorage { get; set; }
        [Inject] private IToastService ToastService { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] private ICargosServico CargosServico { get; set; }
        [Inject] private IEspecialidadesServico EspecialidadesServico { get; set; }
        [Inject] private IAdministradoresServico AdministradoresServico { get; set; }
        [Inject] private IRecepcionistasServico RecepcionistasServico { get; set; }
        [Inject] private ILaboratoriosServico LaboratoriosServico { get; set; }
        [Inject] private IMedicosServico MedicosServico { get; set; }

        private List<CargoDTO> _cargos = new List<CargoDTO>();
        private List<EspecialidadeDTO> _especialidades = new List<EspecialidadeDTO>();
        private UsuarioViewModel _usuarioViewModel = new UsuarioViewModel();
        private string _cargoIdLocalStorage;

        protected async override Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            var dotNetReference = DotNetObjectReference.Create(this);
            await JSRuntime.InvokeVoidAsync("select2JsInterop.startup", "#especialidades", dotNetReference, nameof(SelecionaEspecialidade));
        }

        protected async override Task OnInitializedAsync()
        {
            _cargos = await CargosServico.GetAsync();
            _especialidades = await EspecialidadesServico.GetAsync();

            _cargoIdLocalStorage = await LocalStorage.ObterUsuarioCargoIdLocalStorageAsync();

            switch (_cargoIdLocalStorage)
            {
                case CargosConst.Administrador:
                    var administrador = await AdministradoresServico.GetAsync(Id);
                    _usuarioViewModel = Mapper.Map<UsuarioViewModel>(administrador);
                    break;
                case CargosConst.Recepcionista:
                    var recepcionista = await RecepcionistasServico.GetAsync(Id);
                    _usuarioViewModel = Mapper.Map<UsuarioViewModel>(recepcionista);
                    break;
                case CargosConst.Laboratorio:
                    var laboratorio = await LaboratoriosServico.GetAsync(Id);
                    _usuarioViewModel = Mapper.Map<UsuarioViewModel>(laboratorio);
                    break;
                case CargosConst.Medico:
                    var medico = await MedicosServico.GetAsync(Id);
                    _usuarioViewModel = Mapper.Map<UsuarioViewModel>(medico);
                    break;
            }
        }

        protected async Task Salvar(EditContext editContext)
        {
            if (!editContext.Validate())
                return;

            switch (_usuarioViewModel.CargoId)
            {
                case CargosConst.Administrador:
                    var administrador = Mapper.Map<AdministradorDTO>(_usuarioViewModel);
                    await PostOrPutAsync(AdministradoresServico, administrador);
                    break;
                case CargosConst.Recepcionista:
                    var recepcionista = Mapper.Map<RecepcionistaDTO>(_usuarioViewModel);
                    await PostOrPutAsync(RecepcionistasServico, recepcionista);
                    break;

                case CargosConst.Laboratorio:
                    var laboratorio = Mapper.Map<LaboratorioDTO>(_usuarioViewModel);
                    await PostOrPutAsync(LaboratoriosServico, laboratorio);
                    break;
                case CargosConst.Medico:
                    if (!_usuarioViewModel.Especialidades.Any())
                    {
                        ToastService.ShowWarning("Deve ser selecionado ao menos uma especialidade!");
                        return;
                    }

                    var horariosSelecionados = _usuarioViewModel.HorariosDeTrabalho.Where(_ => _.Selecionado);

                    if (!horariosSelecionados.Any())
                    {
                        ToastService.ShowWarning("Deve ser selecionado ao menos um horário de trabalho!");
                        return;
                    }

                    var medico = Mapper.Map<MedicoDTO>(_usuarioViewModel);
                    await PostOrPutAsync(MedicosServico, medico);
                    break;
                default:
                    ToastService.ShowWarning("O cargo informado é inválido");
                    break;
            }
        }

        private async Task PostOrPutAsync<TServico, TDTO>(TServico servico, TDTO dto)
            where TDTO : IDTO<Guid>
            where TServico : IServicoBase<TDTO, Guid>
        {
            HttpResponseMessage httpResponse;

            if (dto.Id == Guid.Empty)
                httpResponse = await servico.PostAsync(dto);
            else
                httpResponse = await servico.PutAsync(dto.Id, dto);

            if (httpResponse.IsSuccessStatusCode)
                ToastService.ShowSuccess("Registro salvo com sucesso");
            else
                ToastService.ShowError("Falha ao tentar salvar o registro!");

            NavigationManager.NavigateTo("usuarios");
        }

        [JSInvokable]
        public void SelecionaEspecialidade(Select2 select2)
        {
            if (!Guid.TryParse(select2.Id, out Guid especialidadeId))
                return;

            if (_usuarioViewModel.Especialidades.Any(_ => _.EspecialidadeId == especialidadeId))
            {
                var index = _usuarioViewModel.Especialidades.FindIndex(_ => _.EspecialidadeId == especialidadeId);

                if (_usuarioViewModel.Especialidades[index].Id == Guid.Empty)
                    _usuarioViewModel.Especialidades.RemoveAt(index);
                else
                    _usuarioViewModel.Especialidades[index].Ativo = !_usuarioViewModel.Especialidades[index].Ativo;
            }
            else
            {
                _usuarioViewModel.Especialidades.Add(UsuarioViewModel.ControiMedicoEspecialidade(Guid.Empty, especialidadeId, true));
            }
        }
    }
}
