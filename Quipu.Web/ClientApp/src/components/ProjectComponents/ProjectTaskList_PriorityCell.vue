<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="priority"
                  @update:model-value="updatetask()"
                  :options="priorityoptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (priority?.id ?? 0)
                                                                              ? 'visible'
                                                                              : 'hidden'}" />
                            <q-badge rounded 
                                     :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="priority?.color ?? 'primary'"
                         v-if="priority != null">
                    {{priority?.name ?? ''}}
                </q-badge>
            </template>

        </q-select>

    </div>
</template>

<style scoped>
    .cell {
        width: 100%;
        height: 100%;
    }
</style>

<script>
    export default {
        name: "PriorityCell",
        emits: ["update-task"],
        props: {
            task: {},
            priorityoptions: Array,
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                priority: this.task.priority,
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.priority);
            },
        },
    }
</script>