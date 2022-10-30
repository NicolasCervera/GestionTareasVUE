<template>
    <div>
        <h1 class="diplay-4 text-center">Listado de Tareas</h1>
        <hr>
        <div class="col-lg-8 offset-lg-2">
            <div class="card mt-4">
                <div class="card-body">
                    <div class="input-group">
                        <input type="text" class="form-control form-control-lg" placeholder="Agregar tarea" v-model="tarea">
                        <div class="input-group-append">
                            <button v-on:click="agregarTarea()" class="btn btn-success btn-lg">Agregar</button>
                        </div>
                    </div>
                    <br>
        
                    <ul class="list-group">
                        <li v-for="(tarea, index) of listTareas"  :key="index"
                         class="list-group-item d-flex justify-content-between">
                            <span class="cursor"><i class="fa-regular fa-circle"></i></span>
                            {{tarea.nombre}}
                            <span class="text-danger cursor"><i class="fa-solid fa-trash-can"></i></span>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    export default {
        name: 'Tarea',
        data(){
            return{
                tarea: '',
                listTareas:[]
            }
        },
        methods:{
            agregarTarea(){
                const tarea = {
                    nombre: this.tarea,
                    estado: false
                }
                this.listTareas.push(tarea);
                this.tarea = '';
            }
        }
    }
</script>

<style scoped>
.cursor{
    cursor: pointer;
}
</style>