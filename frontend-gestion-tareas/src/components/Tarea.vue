<template>
    <div>
        <h1 class="diplay-4 text-center">Listado de Tareas</h1>
        <hr>
        <div class="col-lg-8 offset-lg-2">
            <div class="card mt-4">
                <div class="card-body">
                    <div class="input-group">
                        <input type="text" class="form-control form-control-lg" placeholder="Agregar tarea"
                            v-model="tarea">
                        <div class="input-group-append">
                            <button v-on:click="agregarTarea()" class="btn btn-success btn-lg">Agregar</button>
                        </div>
                    </div>
                    <br>
                    <!--  {{listTareas}} -->
                    <h5 v-if="listTareas.length == 0">No hay tareas para realizar</h5>
                    <ul class="list-group">
                        <li v-for="(tarea, index) of listTareas" :key="index"
                            class="list-group-item d-flex justify-content-between">
                            <span class="cursor" v-on:click="editarTarea(tarea, index)" v-bind:class="{'text-success': tarea.estado}">
                                <!-- Dos maneras de realizar para dos tipos de estados -->

                               <!--  <i v-if="listTareas[index].estado == false" class="fa-regular fa-circle"></i>
                                <i v-if="listTareas[index].estado == true" class="fa-solid fa-check"></i>-->
                                
                                <i v-bind:class="[tarea.estado ? 'fa-solid fa-circle-check' : 'fa-regular fa-circle']"></i>
                            </span>
                            <p>
                                {{ tarea.nombre }}
                            </p>
                            <span class="text-danger cursor">
                                <i class="fa-solid fa-trash-can" v-on:click="eliminarTarea(index)"></i>
                            </span>
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
    data() {
        return {
            tarea: '',
            listTareas: []
        }
    },
    methods: {
        agregarTarea() {
            const tarea = {
                nombre: this.tarea,
                estado: false
            }
            this.listTareas.push(tarea);
            this.tarea = '';
        },
        eliminarTarea(index) {
            this.listTareas.splice(index, 1)
        },
        editarTarea(tarea, index) {
            this.listTareas[index].estado = !tarea.estado;
        }
    }
}
</script>

<style scoped>
.cursor {
    cursor: pointer;
}
</style>