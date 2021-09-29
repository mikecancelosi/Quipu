<template>
    <div class="cell"
         @mouseenter="hover = true"
         @mouseleave="hover = false">

        <q-select :hide-dropdown-icon="!hover"
                  borderless
                  v-model="status"
                  @update:model-value="updatetask()"
                  :options="allStatusDropdownOptions"
                  dense
                  emit-value>

            <template v-slot:option="scope">
                <q-item v-bind="scope.itemProps">
                    <q-item-section>
                        <div>
                            <q-icon name="o_check"
                                    size="16px"
                                    :style="{visibility: scope.opt.category == (status?.id ?? 0)
                                                                                                                        ? 'visible'
                                                                                                                        : 'hidden'}" />
                            <q-badge rounded :color="scope.opt.value.color">
                                {{scope.opt.label}}
                            </q-badge>
                        </div>
                    </q-item-section>
                </q-item>
            </template>
            <template v-slot:selected>
                <q-badge rounded
                         :color="status?.color ?? 'primary'"
                         v-if="status != null">
                    {{status?.name ?? ''}}
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
    import { mapGetters, mapActions } from 'vuex'
    export default {
        name: "StatusCell",
        emits: ["update-task"],
        props: {
            task: {},
        },
        computed: mapGetters(['allStatusDropdownOptions']),
        created() {
            this.fetchStatusTypes();
        },
        data() {
            return {
                hover: false,
                showdropdown: false,
                status: this.task.status,
            }
        },
        methods: {
            updatetask() {
                this.$emit("update-task", this.status);
            },
            ...mapActions(['fetchStatusTypes']),
        },
    }
</script>