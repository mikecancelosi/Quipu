<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <div class="row">
            <div>
                <q-btn dense
                       round
                       flat
                       v-bind:style="{color: completed ? 'green'                                                                                                           : 'white'}"
                       @click="completed = !completed; updatetask();"
                       class="checkbox"
                       icon="o_check_circle_outline" />
            </div>
            <q-input ref="nameinput"
                     debounce="1000"
                     dense
                     borderless
                     v-model="name"
                     style="height:100%;"
                     @update:model-value="(val)=>tasklostfocus(true)"
                     @blur="(evt)=>tasklostfocus()" />
            <q-space />
            <q-btn label="Details"
                   icon-right="o_chevron_right"
                   flat
                   dense
                   no-caps
                   class="showonhover" 
                   @click="this.detailtask()"/>
        </div>
    </div>
</template>

<style>
    .cell {
        width: 100%;
        height: 100%;
    }
    .checkbox:hover {
        color: green;
    }

    .list-row-noicon .tablecol .showonhover {
        visibility: hidden;
    }

    .list-row-noicon .tablecol:hover .showonhover {
        visibility: visible;
    }
</style>

<script>
    import { ref } from 'vue'

    export default {
        name: "StatusCell",
        emits: ["update-task", "detail-task", "remove-element"],
        props: {
            task: {},
        },
        setup(props) {
            const hover = ref(false);
            const showdropdown = ref(false);
            const name = ref(props.task.value.name );
            const completed = ref(props.task.value.completed);
            const updatetask = () => {
                this.$emit("update-task", this.name, this.completed);
            };

            const tasklostfocus = () => {
                if (name.value === '') {
                    this.$emit("update-task", this.task);
                } else {
                    this.updatetask();
                }
                if (focus) {
                    this.$nextTick(() => { this.$refs['nameinput'].focus(); });
                }
            };          

            const detailtask = () => {
                this.$emit("detail-task");
            };

            return {hover, showdropdown,name,completed, updatetask,tasklostfocus,detailtask}
        },
       
    }
</script>